using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator anim;
    public int hp;
    public int dmg;

    public Player(int hp, int dmg)
    {
        this.hp = hp;
        this.dmg = dmg;
        anim = GetComponent<Animator>();
    }

    public void Attack(Enemy enemy)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.Play("Attack", -1, 0f);
        }
        enemy.Damaged(dmg);
    }

    public void Damaged(int damage)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.Play("Damaged", -1, 0f);
        }
        hp = hp - damage;
    }

}
