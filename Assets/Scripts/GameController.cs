using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject fantasma;
	public Vector2[] posicaoSpawn;
	public float tempoParaSpawn;
	public Text pontosTexto;
	public Text recordeTexto;

	private int pontos;
	private float contaTempo;
	private int recorde;
	private ClickController clickController;


	void Start () {
		clickController = ClickController.FindObjectOfType<ClickController> ();
		recordeTexto.text = "Recorde: " + PlayerPrefs.GetInt ("Recorde").ToString();
	}

	void Update () {
		SpawnFantasma ();
		//clickController.TocouNoFantasma ();
		clickController.ClicouNoFantasma();
	}

	void SpawnFantasma(){
		if (contaTempo >= tempoParaSpawn && FantasmaController.FindObjectOfType<FantasmaController> () == false) {
			Instantiate (fantasma, posicaoSpawn [(int)Mathf.Floor (Random.Range (0.0f, posicaoSpawn.Length))], fantasma.transform.rotation);
			contaTempo = 0.0f;
		} else {
			contaTempo += Time.deltaTime;
		}
	}

	public void ContaPontos(){
		pontos++;
		pontosTexto.text = "Pontos: " + pontos.ToString();
	}

	public int GetPontos(){
		return pontos;
	}

	public void PerdeJogo(){
		RecordeController.FindObjectOfType<RecordeController>().GravaRecorde (pontos);
		SceneManager.LoadScene ("GameOver");
	}
}
