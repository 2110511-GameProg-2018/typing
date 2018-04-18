using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Enemy currentEnemy;
	public Image enemyHealthBar;

    public Enemy[] enemies;
    private int currentStage; //หาก stage ตรง enemy ถึงจะตี
    public Stat stat;
    public TypingUI typingUI;
    public Text statText;
    public Text resultText;
    private int numberEnemy;
    private int maxEnemy = 3;
    private Player _player;


    public Player player {
        get {return _player; }
    }
    
	// Use this for initialization
	void Start () {
        currentStage = 1;
        numberEnemy = 3;
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        _player.maxHp = _player.hp;
		currentEnemy.SetHealthBar (enemyHealthBar);
        _player.running = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public int getNumberEnemy()
    {
        return numberEnemy;
    }
    public void decreaseNumberEnemy()
    {
        numberEnemy--;
    }
    public Enemy getCurrentEnemy()
    {
        return currentEnemy;
    }
    public void setCurrentEnemy(int i)
    {
        currentEnemy = enemies[i];
    }
    public int getCurrentStage()
    {
        return currentStage;
    }
    public void CompleteWord() {
        Debug.Log("COMPLETE WORD");
		_player.Attack(currentEnemy);
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
    public void EndLevel()
    {
        currentStage++;
        stat.running = false;
        typingUI.runinng = false;
        currentEnemy.running = false;
 
    }
    public void startLevel()
    {
        this.setCurrentEnemy(maxEnemy - this.getNumberEnemy());
        stat.running = true;
        typingUI.runinng = true;
        currentEnemy.running = true;
        currentEnemy.SetHealthBar(enemyHealthBar);
    }
}
