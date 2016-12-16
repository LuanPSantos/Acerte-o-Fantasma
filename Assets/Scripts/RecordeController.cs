using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecordeController : MonoBehaviour {

	public Text recordeTexto;
	public Text pontosTextoDoGameController;
	public GameObject[] dados;

	private GameController gameController;


	void Awake() {
		dados = GameObject.FindGameObjectsWithTag ("Dados");
		if (dados.Length >= 2) {
			Destroy (dados [0]);
		}
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		gameController = GameController.FindObjectOfType<GameController> ();
		pontosTextoDoGameController = gameController.pontosTexto;
	}

	void Update () {
		pontosTextoDoGameController = gameController.pontosTexto;
	}

	public void GravaRecorde(int pontosAtual){
		if (pontosAtual > PlayerPrefs.GetInt ("Recorde")) {
			PlayerPrefs.SetInt ("Recorde", pontosAtual);
			recordeTexto.text = PlayerPrefs.GetInt ("Recorde").ToString();
		}
	}
}
