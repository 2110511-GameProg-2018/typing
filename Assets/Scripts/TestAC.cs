using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAC : MonoBehaviour {
    public Player player;
    public Enemy enemy;

    void Start()
    {
        player = new Player(1000, 10);
        enemy = new Enemy(1000, 10);
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            player.Attack(enemy);
        }
        if (Input.GetKeyDown("d"))
        {
            enemy.Attack(player);
        }
    }
}
