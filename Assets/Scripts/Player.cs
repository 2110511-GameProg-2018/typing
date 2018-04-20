using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Animator anim;
    public int dmg;
    public bool running;
	public int maxHp;
	public float maxMana;
    public bool attackCancellation = false;
    private int hp;

    public Image healthBar;
	public Image manaBar;
	public Combo combo;

	private float mana;
	private float manaStep;

    public GameController gameController;
    private Enemy currentEnemy;
    private Weapon currentWeapon;

	void Start() {
		mana = 0;
		manaStep = maxMana / 1000000;	// step = 0.0001%
		hp = maxHp;
		healthBar.fillAmount = 1;
		manaBar.fillAmount = 0;
		anim = GetComponent<Animator>();
	}

	void Update(){
		if (mana + manaStep < maxMana) {
			mana = mana + (manaStep * (combo.getCombo()+1));
		}else{
			mana = maxMana;
		}
		manaBar.fillAmount = mana;
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

    public void setWeapon(Weapon wp) {
        currentWeapon = wp;
    }

    public void Damaged(int damage)
    {
        anim.SetTrigger("DamagedTrigger");
        
        // Prevent the attack occuring after damaged (trigger still set)
        anim.ResetTrigger("AttackTrigger");
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
            currentEnemy.Damaged(dmg + (int) currentWeapon.attackPoints);
        attackCancellation = false;
    }
}

