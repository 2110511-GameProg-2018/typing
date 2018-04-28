using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingUITester : MonoBehaviour {

	public Text scoreText;
	int score = 0;

	// Use this for initialization
	void Start () {
		UpdateScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int score) {
		this.score += score;
		UpdateScoreText ();
	}

	public void UpdateScoreText() {
		scoreText.text = "score = " + score.ToString ();
	}
}
