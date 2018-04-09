using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeath : MonoBehaviour {
    public float time;
    public int timeInSec;

    public Player player;
    public Enemy enemy;

    // Use this for initialization
    void Start () {
        time = 0;
        timeInSec = (int)time;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if((int)time == timeInSec + 3)
        {
            timeInSec += 3;
            if (!player.IsDead())
            {
                enemy.Attack(player);
            }
        }
    }
}
