using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class TypingUI : MonoBehaviour {

	[Serializable]
	public class CompleteWordEvent : UnityEvent{}

	public Text untypedText;
	public Text typedText;
	public CompleteWordEvent onCompleteWord;
    public CompleteWordEvent onWrongword;

	private int wrongCount = 0;

	// Use this for initialization
	void Start () {
		untypedText.text = "mhee ant bird cat dog elephant frog giraffe horse iguana jaguar kangaroo lion monkey " +
						   "narwhal owl penguin quail rat snake turtle urial vulture whale xenathra yak zebra";
		typedText.text = " " + EncodeColor ("", Color.green);
	}
	
	// Update is called once per frame
	void Update () {
		HandleTypeInput ();
	}

	void HandleTypeInput () {
		string input = Input.inputString;
		char c;
		for (int i = 0; i < input.Length; i++) {
			c = input [i];
			if (c == "\b"[0]) {
				TypedBackspace ();
			}
			else if (c == ' ') {
				TypedSpace ();
			}
			else if (c == untypedText.text [0]) {
				TypedChar (c, true);
			}
			else {
				TypedChar (c, false);
			}
		}
	}

	void TypedBackspace() {
		string text = typedText.text;
		string word = GetLastWord (text);

		if (word == "") {
			return;
		}

		if (wrongCount > 0) {
			wrongCount--;
			if (wrongCount == 0) {
				text = ReplaceLastWord (text, EncodeColor (word, Color.green));
			}
		}
		else {
			untypedText.text = untypedText.text.Insert (0, word[word.Length-1].ToString());
		}

		typedText.text = text = text.Remove (text.LastIndexOf('<')-1, 1);;
	}

	void TypedSpace() {
		string text = typedText.text;
		string word = GetLastWord (text);

		if (word == "") {
			return;
		}
		if (untypedText.text [0] != ' ') {
			text = ReplaceLastWord (text, EncodeColor (word, Color.red));
            onWrongword.Invoke ();
		}
		else {
			onCompleteWord.Invoke ();
		}

		wrongCount = 0;
		untypedText.text = untypedText.text.Remove (0, untypedText.text.IndexOf(' ') + 1);
		typedText.text = text.Insert (text.Length, " " + EncodeColor("", Color.green));
	}

	void TypedChar(char c, bool correct) {
		string text = typedText.text;

		if (!correct) {
			if (wrongCount == 0) {
				string word = GetLastWord (text);
				text = ReplaceLastWord (text, EncodeColor (word, Color.red));
			}
			wrongCount++;
		}
		else if (wrongCount == 0) {
			untypedText.text = untypedText.text.Remove (0, 1);
		}
		else {
			wrongCount++;
		}

		typedText.text = text.Insert (text.LastIndexOf("<"), c.ToString());
	}

	string ReplaceLastWord(string text, string word) {
		int start = text.LastIndexOf (' ') + 1;
		text = text.Remove (start);
		return text.Insert (start, word);
	}

//	string InsertWord(string text, string word) {
//		int start = text.LastIndexOf (' ') + 1;
//		return text.Insert (start, word);
//	}

//	string RemoveLastWord(string s) {
//		int start = s.LastIndexOf (' ') + 1;
//		return s.Remove (start);
//	}

	string GetLastWord(string s) {
		int start = s.LastIndexOf (' ') + 1;
		int length = s.LastIndexOf ('>') - start + 1;
		return DecodeColor(s.Substring (start, length));
	}

	string EncodeColor(string s, Color color) {
		return "<color=#" + ((int)(color.r*255)).ToString("X2") + 
							((int)(color.g*255)).ToString("X2") + 
							((int)(color.b*255)).ToString("X2") + ">" + s + "</color>";
	}

	string DecodeColor(string s) {
		int start = s.IndexOf ('>');
		int stop = s.LastIndexOf ('<');
		return s.Substring(start+1, stop-start-1);
	}
}
