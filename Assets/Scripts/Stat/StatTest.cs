using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTest : MonoBehaviour {
    public Stat typingStat;
    public Text typingStatText;

	// Use this for initialization
	void Start () {
        UpdateStatText();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateStatText();
    }

    public void UpdateStatText()
    {
        typingStatText.text = "Time = " + (int)typingStat.time 
            + "  WPM = " + typingStat.wpm + "  CPM = " + typingStat.cpm 
            +"\nCorrect Word = " + typingStat.correctWord + "  Wrong Word = " + typingStat.wrongWord
            +"\nAccuracy = " + typingStat.accuracy + "  Correct Char = " + typingStat.correctChar;
    }
}
