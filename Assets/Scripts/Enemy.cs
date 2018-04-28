﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int hp;
    public int dmg;
	public float attackPeriod;
    public bool running;
    public int stageOfEnemy;
    private Image healthBar;
	private int maxHp;
	private Player player;
	private float attackTimer;
    
    public GameController gameController;

    public Enemy(int hp, int dmg)
    {
        this.hp = hp;
        this.dmg = dmg;
		maxHp = hp;
        anim = GetComponent<Animator>();
    }

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		attackTimer = attackPeriod;
        if(stageOfEnemy == gameController.getCurrentStage())
        {
            running = true;
        }
    }

	void Update () {

		//don't do anything without target
		if(player == null) return;

        //found target, what now ?
        if (running)
        {
            if (attackTimer > 0f)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    Attack(player);
                }
            }
        }
	}

    public void Attack(Player player)
    {
        anim.SetTrigger("AttackTrigger");
        // anim.Play("Attack", -1, 0f);
        attackTimer = attackPeriod;
    }

    public void Damaged(int damage)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            // Set the animation to be 'damaged'
            anim.SetTrigger("DamagedTrigger");

            // anim.Play("Damaged", -1, 0f);
        }
        hp = hp - damage;

        if (hp <= 0)
        {
            hp = 0;
            Die();
        }

		healthBar.fillAmount = (float)hp / (float)maxHp;
    }

	public void SetHealthBar(Image image) {
		healthBar = image;
		healthBar.fillAmount = 1;
		maxHp = hp;
	}

    public void Die()
    {
        anim.SetTrigger("DeadTrigger");
        gameController.decreaseNumberEnemy();
        // anim.Play("Death", -1, 0f);
        if (gameController.getNumberEnemy() > 0)
        {
            gameController.EndLevel();
        }
        else{
            gameController.EndGame("YOU WIN !!");
        }
    }

    public bool IsDead()
    {
        return hp == 0;
    }


    /* This function is called on AnimationEvent 'HIT' */
    private void Hit() 
    {
        Debug.Log("Hit");
        if (running)
        {
            gameController.player.Damaged(dmg);
            gameController.player.attackCancellation = true;
        }
    }

    private void OnAttackFinish()
    {
        Debug.Log("Attack Finished");
        if (running)
        {   
            Debug.Log("Removed Attack Cancellation");
            gameController.player.attackCancellation = false;
        }
    }
}
