﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Enemy currentEnemy;
	public Image enemyHealthBar;

    public Stat stat;
    public TypingUI typingUI;
    public Text statText;

    private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		currentEnemy.SetHealthBar (enemyHealthBar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CompleteWord() {
		player.Attack (currentEnemy);
	}

    public void EndGame()
    {
        stat.running = false;
        typingUI.runinng = false;
        statText.text = "Time = " + (int)stat.time
            + "  WPM = " + stat.wpm + "  CPM = " + stat.cpm
            + "\nCorrect Word = " + stat.correctWord + "  Wrong Word = " + stat.wrongWord
            + "\nAccuracy = " + stat.accuracy + "  Correct Char = " + stat.correctChar;
    }
}
