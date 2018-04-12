using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public Weapon currentWeapon;
    public int hp;
    public int dmg;
    public bool running = true;
    public bool attackCancellation = false;

    public Image healthBar;
	public Image manaBar;
    public int maxHp;

    public GameController gameController;
    private Enemy currentEnemy;

    public Player(int hp, int dmg)
    {
        this.hp = hp;
        this.dmg = dmg;
        maxHp = hp;
		healthBar.fillAmount = 1;
        anim = GetComponent<Animator>();
    }

    public void Attack(Enemy enemy)
    {
        if (running)
        {
            currentEnemy = enemy;
            anim.SetTrigger("AttackTrigger");
            // anim.Play("Attack", -1, 0f);
            
        }
    }

    public void Damaged(int damage)
    {
        anim.SetTrigger("DamagedTrigger");
        // anim.Play("Damaged", -1, 0f);
        hp = hp - damage;

        if (hp <= 0)
        {
            hp = 0;
            Die();
        }

		healthBar.fillAmount = (float)hp / (float)maxHp;
    }

    public void Die()
    {
        anim.SetTrigger("DeadTrigger");
        // anim.Play("Death", -1, 0f);
        gameController.EndGame("YOU LOSE !!");
    }

    public bool IsDead()
    {
        return hp == 0;
    }

    /* This function is called on AnimationEvent 'HIT' */
    private void Hit() 
    {
        if(!attackCancellation)
            currentEnemy.Damaged(dmg);
        attackCancellation = false;
    }
}
