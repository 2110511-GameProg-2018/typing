using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public Weapon currentWeapon;
    public int hp;
    public int dmg;
	public int maxHp;
	public float maxMana;

	public Image healthBar;
	public Image manaBar;
	public Combo combo;

	private float mana;
	private float manaStep;

    public GameController gameController;

	void Start(){
		mana = 0;
		manaStep = maxMana / 1000000;	// step = 0.0001%
		maxHp = hp;
		healthBar.fillAmount = 1;
		manaBar.fillAmount = 0;
		anim = GetComponent<Animator>();
	}

	void Update(){
		print (manaStep);
		if (mana + manaStep < maxMana) {
			mana = mana + (manaStep * (combo.getCombo()+1));
		}else{
			mana = maxMana;
		}
		manaBar.fillAmount = mana;
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
