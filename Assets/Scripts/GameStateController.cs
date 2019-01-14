using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour {

	public float GameOverScreenDelay = 2.0f;
	public string GameOverScene = "GameOver";
	private uint CurrentScore = 0;
	public static GameStateController Instance { get; private set; }
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void OnPlayerSpawned()
	{
		CurrentScore = 0;
	}

	public void OnPlayerDied()
	{
		Invoke ("ShowGameOverScreen", GameOverScreenDelay);
	}

	public void IncrementScore(uint scoreToAdd)
	{
		CurrentScore += scoreToAdd;
	}
	public uint GetCurrentScore()
	{
		return CurrentScore;
	}


	void ShowGameOverScreen()
	{
		SceneManager.LoadScene (GameOverScene);
	}
}
