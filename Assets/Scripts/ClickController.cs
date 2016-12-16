using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

	private GameController gameController;
	private FantasmaController fantasmaController;
	public float velocidadeDoFantasma;
	public float velocidadeMaximaDoFantasma;
	public float encrementoDaVelocidadeDoFantasma;
	public AudioSource somPorrada;
	private GameObject luz;

	void Start () {
		luz = GameObject.FindWithTag ("Luz");
		gameController = GameController.FindObjectOfType<GameController> ();
	}

	void Update(){
		fantasmaController = FantasmaController.FindObjectOfType<FantasmaController> ();
	}

	public void ClicouNoFantasma(){
		Vector2 pontoNoMundo = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (pontoNoMundo, Vector2.zero);
			if (hit.collider != null && hit.collider.CompareTag ("Fantasma") && fantasmaController.jaClicouNoFantasma == false) {
				if (velocidadeDoFantasma < velocidadeMaximaDoFantasma) {
					velocidadeDoFantasma += encrementoDaVelocidadeDoFantasma;
				}
				Som ();
				luz.GetComponent<SpriteRenderer> ().color = fantasmaController.corLuz;
				fantasmaController.jaClicouNoFantasma = true;
				fantasmaController.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				gameController.ContaPontos ();

				return;
			} else {
				gameController.PerdeJogo ();
			}
		}
	}

	public void TocouNoFantasma(){
		Touch touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began) {
			Vector2 pontoNoMundo = Camera.main.ScreenToWorldPoint (touch.position);
			RaycastHit2D hit = Physics2D.Raycast (pontoNoMundo, Vector2.zero);
			if (hit.collider != null && hit.collider.CompareTag ("Fantasma") && fantasmaController.jaClicouNoFantasma == false) {
				if (velocidadeDoFantasma < velocidadeMaximaDoFantasma) {
					velocidadeDoFantasma += encrementoDaVelocidadeDoFantasma;
				}
				Som ();
				luz.GetComponent<SpriteRenderer> ().color = fantasmaController.corLuz;
				fantasmaController.jaClicouNoFantasma = true;
				fantasmaController.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				gameController.ContaPontos ();

				return;
			} else {
				gameController.PerdeJogo ();
			}
		}

	}

	public void Som(){
		somPorrada.Play ();
	}
}
