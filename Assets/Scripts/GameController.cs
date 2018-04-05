using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Enemy currentEnemy;
	public Image enemyHealthBar;

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
}
