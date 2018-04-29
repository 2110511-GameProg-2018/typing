using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkPlayerRun : MonoBehaviour {

	public GameController gameController;
	public float velocity = 4.0f;

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
		this.setKeyHit(false);
		anim.SetBool("isRunning", false);
		rg.velocity = new Vector3(0, 0, 0);
		gameController.startLevel();
	}
}
