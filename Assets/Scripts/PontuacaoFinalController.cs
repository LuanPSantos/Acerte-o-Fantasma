using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PontuacaoFinalController : MonoBehaviour {

	public Text pontuacaoFinal, recorde;

	private RecordeController recordeController;

	void Start () {
		recordeController = RecordeController.FindObjectOfType<RecordeController> ();

		pontuacaoFinal.text = "Pontuação: " + recordeController.pontosTextoDoGameController.text;
		recorde.text = "Recorde: " + recordeController.recordeTexto.text;
	}
}
