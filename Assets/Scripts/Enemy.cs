using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int hp;
    public int dmg;

	private Image healthBar;
	private int maxHp;

    public GameController gameController;

    public Enemy(int hp, int dmg)
    {
        this.hp = hp;
        this.dmg = dmg;
		maxHp = hp;
        anim = GetComponent<Animator>();

    }

    public void Attack(Player player)
    {
        if (!IsDead())
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Attack", -1, 0f);
            }
            player.Damaged(dmg);
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

	public void SetHealthBar(Image image) {
		healthBar = image;
		healthBar.fillAmount = 1;
		maxHp = hp;
	}

    public void Die()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.Play("Death", -1, 0f);
        }
        gameController.EndGame("YOU WIN !!");
    }

    public bool IsDead()
    {
        return hp == 0;
    }
}
