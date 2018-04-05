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

    public TypingUI typingUI;
    public bool running = true;

    void Start () {
        correctWord = 0;
        correctChar = 0;
        wrongWord = 0;
        time = 0;
	}
	
	void Update () {
        if (running)
        {
            time += Time.deltaTime;
            Calculate();
        }
	}   
    public void UpdateCorrectWord()
    {
        correctWord += 1;
        correctChar += typingUI.charCount;
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
