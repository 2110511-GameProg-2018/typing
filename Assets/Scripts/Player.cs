using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public Weapon currentWeapon;
    public int hp;
    public int dmg;

	public Image healthBar;
	public Image manaBar;
    public int maxHp;

    public GameController gameController;

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
        if (!IsDead())
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Attack", -1, 0f);
            }
            enemy.Damaged(dmg);
        }
    }

    public void Damaged(int damage)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.Play("Damaged", -1, 0f);
        }
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
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.Play("Death", -1, 0f);
        }
        gameController.EndGame("YOU LOSE !!");
    }

    public bool IsDead()
    {
        return hp == 0;
    }
}
