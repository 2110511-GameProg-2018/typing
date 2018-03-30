using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator anim;
    public int hp;

	void Start () {
        anim = GetComponent<Animator>();
        hp = 100;
	}

    // Update use for Test
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Attack();
        }
        if (Input.GetKeyDown("d"))
        {
            Damaged(1);
            print("HP = " + hp);
        }
    }

    public void Attack()
    {
        anim.Play("Attack", -1, 0f);
    }

    public void Damaged(int damage)
    {
        anim.Play("Damaged", -1, 0f);
        hp = hp - damage;
    }
}
