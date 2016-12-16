using UnityEngine;
using System.Collections;

public class FantasmaController : MonoBehaviour {

	public bool jaClicouNoFantasma;
	public Color corLuz;

	private GameObject luz;
	private CircleCollider2D circleCollider2D;
	private float posicaoInicial;
	private float distanciaLimite = 0.75f;
	private float distanciaInicialDaVida = 0.3f;
	private float velocidade = 0.1f;

	void Start () {
		luz = GameObject.FindWithTag ("Luz");
		corLuz = luz.GetComponent<SpriteRenderer> ().color;
		jaClicouNoFantasma = false;
		posicaoInicial = transform.position.y;
		circleCollider2D = GetComponent<CircleCollider2D> ();
		circleCollider2D.enabled = false;
		velocidade = ClickController.FindObjectOfType<ClickController>().velocidadeDoFantasma;
	}

	void Update () {
		transform.Translate (0.0f, velocidade * Time.deltaTime, 0.0f);

		if (transform.position.y >= posicaoInicial + distanciaInicialDaVida && jaClicouNoFantasma == false) {
			//this.GetComponent<SpriteRenderer> ().color = Color.red; 
			luz.GetComponent<SpriteRenderer>().color = Color.red;
			circleCollider2D.enabled = true;
		}

		if (transform.position.y >= posicaoInicial + distanciaLimite) {
			if (jaClicouNoFantasma == false) {
				Destroy (this.gameObject);
				GameController.FindObjectOfType<GameController> ().PerdeJogo ();
			}else{
				Destroy (this.gameObject);
			}
		}
	}
}
