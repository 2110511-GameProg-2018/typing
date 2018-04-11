using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public Weapon currentWeapon;
    public int hp;
    public int dmg;
    public float attackDelay;
    public bool running = true;
    public bool attackCancellation = false;

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
        if (running)
        {
            anim.Play("Attack", -1, 0f);
            StartCoroutine(Delay(enemy));
            attackCancellation = false;
        }
    }

    public void Damaged(int damage)
    {
        anim.Play("Damaged", -1, 0f);
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
        anim.Play("Death", -1, 0f);
        gameController.EndGame("YOU LOSE !!");
    }

    public bool IsDead()
    {
        return hp == 0;
    }

    private IEnumerator Delay(Enemy enemy)
    {
        yield return new WaitForSeconds(attackDelay);

        if(!attackCancellation)
            enemy.Damaged(dmg);
    }
}
