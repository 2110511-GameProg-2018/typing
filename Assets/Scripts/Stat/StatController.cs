using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour {

    private int _correctWord;
    private int _correctChar;
    private int _wrongWord;
    private int _accuracy;
    private int _wpm;
    private int _cpm;
    private float _time;
    
    private bool _running;
    
    private TypingController typingUI;

    // Getters and Setters
    public int correctWord {
        get { return _correctWord; }
    }

    public int correctChar {
        get { return _correctChar; }
    }

    public int wrongWord {
        get { return _wrongWord; }
    }

    public int accuracy {
        get { return _accuracy; }
    }

    public int wpm {
        get { return _wpm; }
    }

    public int cpm {
        get { return _cpm; }
    }

    public float time {
        get { return _time; }
    }

    public bool running {
        get { return _running; }
        set { _running = value; }
    }
    
    void Start () {

        // Controllers
        Controllers controllers = GameObject.FindGameObjectWithTag("Controllers").GetComponent<Controllers>();
        typingUI = controllers.typingController;

        _correctWord = 0;
        _correctChar = 0;
        _wrongWord = 0;
        _time = 0;

        _running = true;
	}
	
	void Update () {
        if (_running)
        {
            _time += Time.deltaTime;
            Calculate();
        }
	}   

    public void removeTime(float t) {
        _time -= t;
    }
    
    public void UpdateCorrectWord()
    {
        _correctWord += 1;
        _correctChar += typingUI.charCount;
    }

    public void UpdateWrongWord()
    {
        _wrongWord += 1;
    }

    public void Calculate()
    {
        if ((int) _time == 0)
        {
            _wpm = 0;
            _cpm = 0;
        }
        else
        {
            _wpm = _correctWord * 60 / (int)_time;
            _cpm = _correctChar * 60 / (int)_time;
        }

        if(_correctWord + _wrongWord == 0)
        {
            _accuracy = 0;
        }
        else {
            _accuracy = _correctWord * 100 / (_correctWord + _wrongWord);
        }
    }
}
