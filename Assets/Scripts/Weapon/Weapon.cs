using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private WordSet _wordSet;
    public WordSet wordSet
    {
        get { return _wordSet; }
        set { _wordSet = value; }
    }
    public Ultimate ultimate;
    public float attackPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
