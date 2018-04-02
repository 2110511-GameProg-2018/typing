using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour {
    public int correctWord;
    public int correctChar;
    public int wrongWord;
    public int accuracy;
    public int wpm;
    public int cpm;
    public float time;

	void Start () {
        correctWord = 0;
        correctChar = 0;
        wrongWord = 0;
        time = 0;
	}
	
	void Update () {
        time += Time.deltaTime;
        Calculate();
	}
    /*
    public void UpdateCorrectWord(int charInWord)
    {
        correctWord += 1;
        correctChar += charInWord;
    }
    */

    public void UpdateCorrectWord()
    {
        correctWord += 1;
        correctChar += 3;
    }

    public void UpdateWorngWord()
    {
        wrongWord += 1;
    }

    public void Calculate()
    {
        if ((int)time == 0)
        {
            wpm = 0;
            cpm = 0;
        }
        else
        {
            wpm = correctWord * 60 / (int)time;
            cpm = correctChar * 60 / (int)time;
        }
        if(correctWord + wrongWord == 0)
        {
            accuracy = 0;
        }
        else {
            accuracy = correctWord * 100 / (correctWord + wrongWord);
        }
    }
}
