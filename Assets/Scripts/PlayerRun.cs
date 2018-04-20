using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {

    public GameObject target;
    private Vector3 startPos; //Start
    private Vector3 endPos; //End
    private float distance = 12f;
    private float lerpTime = 3.5f;
    private float currentLerpTime = 0;
    private bool keyhit = false;
    private Player player;
    public GameController gameController;
    private Animator anim;

    public Vector3 getStartPos()
    {
        return this.startPos;
    }
    public Vector3 getEndPos()
    {
        return this.endPos;
    }
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
        startPos = this.transform.position;
        endPos = this.transform.position + Vector3.forward * distance;
        anim = GetComponent<Animator>();
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
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, Perc);
            if(this.transform.position == this.getEndPos())
            {
                this.setKeyHit(false);
                anim.SetBool("isRunning", false);
                gameController.startLevel();
                startPos = this.transform.position;
                endPos = this.transform.position + Vector3.forward * distance;
                currentLerpTime = 0;
            }
        }
    }
}
