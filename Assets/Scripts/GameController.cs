using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Image enemyHealthBar;
    public Stat stat;
    public string nextLevel;

    public GameObject nextLevelButton;

    public Enemy[] enemies;
	private Enemy currentEnemy;
    private int currentStage; //หาก stage ตรง enemy ถึงจะตี
    public TypingUI typingUI;
    public Text statText;
    public Text resultText;
    public GameObject endPanel;
    private int numberEnemy;
    private int maxEnemy = 3;
    private Player _player;
    private PlayerRun _playerRun;


    public Player player {
        get {return _player; }
    }
    
	// Use this for initialization
	void Start () {
        if (enemies == null || enemies.Length == 0) {
            Debug.LogError("No enemy set in GameController!");
        }
        currentEnemy = enemies[0];
        currentStage = 1;
        numberEnemy = 3;
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		_playerRun = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerRun> ();
		currentEnemy.SetHealthBar (enemyHealthBar);
        _player.running = true;
        endPanel.SetActive(false);
        nextLevelButton.SetActive(false);
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
        endPanel.SetActive(true);
        nextLevelButton.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
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
