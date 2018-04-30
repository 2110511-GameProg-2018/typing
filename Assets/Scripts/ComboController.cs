using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour {

    public Text comboText;
    
	private int combo;
	
	void Start () {
        combo = 0;
        UpdateCombo();
	}

    void UpdateCombo()
    {
		if (combo > 0) {
			comboText.enabled = true;
			if (combo == 1) {
				comboText.text = combo.ToString () + " Combo";
			} else {
				comboText.text = combo.ToString() + " Combos";
			}
		} else {
			comboText.enabled = false;
		}
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

	public int getCombo(){
		return combo;
	}
}
