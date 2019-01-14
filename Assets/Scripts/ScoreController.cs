using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreLabel;
	public string scoreText = "Score: {0}";
	void Start () {
		uint currentScore = 0;
		var gameStateController = GameStateController.Instance;
		if (gameStateController) {
			currentScore = gameStateController.GetCurrentScore ();
		}
		scoreLabel.text = string.Format (scoreText, currentScore);
	}
}
