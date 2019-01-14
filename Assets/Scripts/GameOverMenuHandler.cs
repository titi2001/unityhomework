using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour {

	public string GameScene = "Main";
	public void RestartGame()
	{
		SceneManager.LoadScene(GameScene);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
