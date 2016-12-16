using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotoesController : MonoBehaviour {

	public void Reiniciar(){
		SceneManager.LoadScene ("GamePlay");
	}

	public void Sair(){
		//Debug.Log ("SAIU DO JOGO");
		Application.Quit();
	}

	public void Jogar(){
		SceneManager.LoadScene ("GamePlay");
	}
}
