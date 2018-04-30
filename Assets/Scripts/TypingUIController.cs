using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingUIController : MonoBehaviour {

	public TypingUI normalTypingUI;
	public TypingUI ultimateTypingUI;

	public float prepareTime = 1;

	private GameController gc;

	private TypingUIState _state;
	private float timeCounter = 0;

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

		if (state == TypingUIState.PREPARE) {
			timeCounter -= Time.deltaTime;
			if (timeCounter <= 0) {
				state = TypingUIState.NORMAL;
			}
		}
		if (state == TypingUIState.ULTING) {
			if (ultimateTypingUI.canvas.alpha > 0) {
				ultimateTypingUI.canvas.alpha -= Time.deltaTime;
			}
			else {
				ultimateTypingUI.canvas.alpha = 0;
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
			else if (value == TypingUIState.PREPARE) {
				_state = value;
				SetNormalRunning (false);
				ultimateTypingUI.running = false;
				ultimateTypingUI.typedText.enabled = true;
				ultimateTypingUI.untypedText.enabled = true;
				ultimateTypingUI.canvas.alpha = 1.0f;
				timeCounter = prepareTime;
			}
			else if (value == TypingUIState.ULTING && _state == TypingUIState.ULTI) {
				_state = value;
				ultimateTypingUI.running = false;
				timeCounter = prepareTime;
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
			gc.getCurrentEnemy ().running = false;
		}
		else {
			ultimateTypingUI.running = false;
			ultimateTypingUI.typedText.enabled = false;
			ultimateTypingUI.untypedText.enabled = false;
			gc.getCurrentEnemy ().running = true;
		}
	}

	public void SetState(int newState) {
		state = (TypingUIState) newState;
	}
}
