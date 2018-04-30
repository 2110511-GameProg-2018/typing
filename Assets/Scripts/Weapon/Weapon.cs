using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    public Ultimate ultimate;
    public float attackPoints;

    private bool _isUnlocked;
    private WordSet _wordSet;

    public bool isUnlocked {
        get { return _isUnlocked; }
        set { _isUnlocked = value; }
    }

    public WordSet wordSet
    {
        get { return _wordSet; }
        set { _wordSet = value; }
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
