using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    // Public Fields //

    [Tooltip("The name of the next level scene in build settings.")]
    public string nextLevelName;

    public Enemy[] enemies;
    
    [Header("UI Elements")]
    
    [Tooltip("The global enemy healthbar UI element")]
	public Image enemyHealthBar;

    public GameObject endPanel;

    public GameObject nextLevelButton;
    public GameObject retryButton;
    public Text statText;
    public Text resultText;

    // Private Fields //

	private Enemy currentEnemy;
    private int currentStage; //หาก stage ตรง enemy ถึงจะตี
    private int numberEnemy;
    private int maxEnemy = 3;
    
    private Player _player;
    private PlayerRun _playerRun;

    // Controllers
    private StatController statController;
    private TypingController typingController;
    

    // Getters and Setters
    public Player player {
        get {return _player; }
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
    
	void Start () {

        // Next Level Configuration
        if (nextLevelName == null || nextLevelName == "") {
            Debug.LogError("Next level name is not set!");
        } else if (! Application.CanStreamedLevelBeLoaded(nextLevelName)) {
            Debug.LogError("Cannot load level with name: " + nextLevelName);
        }

        // Enemy Configuration
        if (enemies == null || enemies.Length == 0) {
            Debug.LogError("No enemy set in GameController!");
        }
        currentEnemy = enemies[0];
        currentStage = 1;
        numberEnemy = enemies.Length;

        // Set Controllers
        Controllers controllers = GameObject.FindGameObjectWithTag("Controllers").GetComponent<Controllers>();
        statController = controllers.statController;
        typingController = controllers.typingController;

        // Player Components
        GameObject _playerObject = GameObject.FindGameObjectWithTag ("Player");
		_player = _playerObject.GetComponent<Player> ();
		_playerRun = _playerObject.GetComponent<PlayerRun> ();
        _player.running = true;
    
        // UI Elements
		currentEnemy.SetHealthBar (enemyHealthBar);
        endPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        retryButton.SetActive(false);
    }
	
    public void CompleteWord() {
        Debug.Log("COMPLETE WORD");
		_player.Attack(currentEnemy);
	}

    public void EndGame(string result)
    {

        statController.running = false;
        typingController.running = false;
        currentEnemy.running = false;
        _player.running = false;

        resultText.text = result;
        statText.text = "Time = " + (int)statController.time
            + "  WPM = " + statController.wpm + "  CPM = " + statController.cpm
            + "\nCorrect Word = " + statController.correctWord + "  Wrong Word = " + statController.wrongWord
            + "\nAccuracy = " + statController.accuracy + "  Correct Char = " + statController.correctChar;
        endPanel.SetActive(true);

        if (result == "YOU WIN !!")
        {
            nextLevelButton.SetActive(true);
        }
        else
        {
            retryButton.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndLevel()
    {
        currentStage++;
        statController.running = false;
        typingController.running = false;
        currentEnemy.running = false;
 
    }
    public void startLevel()
    {
        this.setCurrentEnemy(maxEnemy - this.getNumberEnemy());
        statController.running = true;
        typingController.running = true;
        currentEnemy.running = true;
        currentEnemy.SetHealthBar(enemyHealthBar);
    }
}
