using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Public Fields //
	public int maxHp;
    public int dmg;
	public float attackPeriod;
    public bool running;
    public int stageOfEnemy;
    public bool isMainMenu;

    // Private Fields //
    private Image healthBar;
    private int hp;
	private Player player;
	private float attackTimer;
    private bool isDead;
    
    private Animator anim;

    private GameController gameController;

    void Awake () {
        hp = maxHp;
    }


	void Start () {
        isDead = false;
        if (maxHp == 0) {
            Debug.Log("Error: Enemy Max HP cannot be set to 0!");
        }
        if (!isMainMenu)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            anim = GetComponent<Animator>();

            // Get game controller from controllers
            Controllers controllers = GameObject.FindGameObjectWithTag("Controllers").GetComponent<Controllers>();
            gameController = controllers.gameController;

            attackTimer = attackPeriod;
            if (stageOfEnemy == gameController.getCurrentStage())
            {
                running = true;
            }
        }
    }

	void Update () {

		// If target is not found, do nothing.
		if(player == null) return;

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
        attackTimer = attackPeriod;
    }

    public void Damaged(int damage)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            // Set the animation to be 'damaged'
            anim.SetTrigger("DamagedTrigger");
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
		hp = maxHp;
	}

    public void Die()
    {   
        if(!isDead) {
            isDead = true;
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
