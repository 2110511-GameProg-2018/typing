using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Enemy currentEnemy;
	public Image enemyHealthBar;

    public Stat stat;
    public TypingUI typingUI;
    public Text statText;
    public Text resultText;

    private Player _player;
    public Player player {
        get {return _player; }
    }

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        _player.maxHp = _player.hp;
		currentEnemy.SetHealthBar (enemyHealthBar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CompleteWord() {
		_player.Attack (currentEnemy);
	}

    public void EndGame(string result)
    {
        stat.running = false;
        typingUI.runinng = false;
        currentEnemy.running = false;
        _player.running = false;
        resultText.text = result;
        statText.text = "Time = " + (int)stat.time
            + "  WPM = " + stat.wpm + "  CPM = " + stat.cpm
            + "\nCorrect Word = " + stat.correctWord + "  Wrong Word = " + stat.wrongWord
            + "\nAccuracy = " + stat.accuracy + "  Correct Char = " + stat.correctChar;
    }
}
