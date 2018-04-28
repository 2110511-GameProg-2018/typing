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
				normalTypingUI.running = true;
				ultimateTypingUI.running = false;
			}
			else if (value == TypingUIState.ULTI) {
				_state = value;
				normalTypingUI.running = false;
				ultimateTypingUI.running = true;
			}
		}
	}

	public void SetState(int newState) {
		state = (TypingUIState) newState;
	}
}
