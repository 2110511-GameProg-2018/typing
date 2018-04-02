using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour {
    public Text comboText;
    private int combo;
	// Use this for initialization
	void Start () {
        combo = 0;
        UpdateCombo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void UpdateCombo()
    {
        comboText.text = "Combo :" + combo.ToString();
    }
    public void increaseCombo()
    {
        combo++;
        UpdateCombo();
    }
    public void failCombo()
    {
        combo = 0;
        UpdateCombo();
    }
}
