using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkPlayerRun : MonoBehaviour {

	public float velocity = 4.0f;

	private GameController gameController;

	private bool keyhit = false;
	private Animator anim;
	private Rigidbody rg;

	public bool getKeyHit()
	{
		return keyhit;
	}
	public void setKeyHit(bool boolean)
	{
		this.keyhit = boolean;
	}

	// Use this for initialization
	void Start () {
		Controllers controllers = GameObject.FindGameObjectWithTag("Controllers").GetComponent<Controllers>();
        gameController = controllers.gameController;

		anim = GetComponent<Animator>();
		rg = GetComponent<Rigidbody> ();
		
	}

	// Update is called once per frame
	void Update () {
		if (gameController.getCurrentEnemy().IsDead() && gameController.getNumberEnemy() > 0)
		{
			this.setKeyHit(true);
		}

		if (this.getKeyHit() == true)
		{
			anim.SetBool("isRunning", true);
//			transform.position = transform.position + Vector3.forward * velocity * Time.deltaTime * transform.lossyScale.x;
			rg.velocity = Vector3.forward * velocity * transform.lossyScale.x;
		}
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log("OnTriggerEnter");
		this.setKeyHit(false);
		anim.SetBool("isRunning", false);
		rg.velocity = new Vector3(0, 0, 0);
		gameController.startLevel();
	}
}
