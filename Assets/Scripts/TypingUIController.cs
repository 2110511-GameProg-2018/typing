using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingUIController : MonoBehaviour {

	public TypingUI normalTypingUI;
	public TypingUI ultimateTypingUI;

	private TypingUIState _state;

	// Use this for initialization
	void Start () {
		state = TypingUIState.NORMAL;
	}
	
	// Update is called once per frame
	void Update () {
		string input = Input.inputString;
		char c;
		for (int i = 0; i < input.Length; i++)
		{
			c = input[i];
			if (c == "\r"[0])
			{
				if (state == TypingUIState.NORMAL) {
					state = TypingUIState.ULTI;
				}
			}
		}
	}
		
	public TypingUIState state {
		get { 
			return _state;
		}
		set { 
			if (value == TypingUIState.NORMAL) {
				_state = value;
				SetNormalRunning (true);
				SetUltimateRunning (false);
			}
			else if (value == TypingUIState.ULTI) {
				_state = value;
				SetNormalRunning (false);
				SetUltimateRunning (true);
				ultimateTypingUI.Reset ();
				ultimateTypingUI.AddWord (7);
			}
		}
	}

	void SetNormalRunning (bool b) {
		if (b) {
			normalTypingUI.running = true;
			normalTypingUI.canvas.alpha = 1.0f;
		}
		else {
			normalTypingUI.running = false;
			normalTypingUI.canvas.alpha = 0.3f;
		}
	}

	void SetUltimateRunning (bool b) {
		if (b) {
			ultimateTypingUI.running = true;
			ultimateTypingUI.typedText.enabled = true;
			ultimateTypingUI.untypedText.enabled = true;
		}
		else {
			ultimateTypingUI.running = false;
			ultimateTypingUI.typedText.enabled = false;
			ultimateTypingUI.untypedText.enabled = false;
		}
	}

	public void SetState(int newState) {
		state = (TypingUIState) newState;
	}
}
