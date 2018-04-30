using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class TypingController : MonoBehaviour {

    [Serializable]
    public class CompleteWordEvent : UnityEvent { }

    [Serializable]
    public class WrongWordEvent : UnityEvent { }
    
    public Color correctColor;
	public Color wrongColor;

    public Text untypedText;
    public Text typedText;
	private WordSetGenerator wordSetGenerator = new WordSetGenerator();
	private WordSetLoader wordSetLoader = new WordSetLoader();

    public CompleteWordEvent onCompleteWord;
    public WrongWordEvent onWrongWord;

    public int charCount = 0;
	
    private StatController typingStat;

    public bool running = true;

    private int wrongCount = 0;
	private int wordLeftCount = 0;

	// Use this for initialization
	void Start () {
		// Controlelrs
        Controllers controllers = GameObject.FindGameObjectWithTag("Controllers").GetComponent<Controllers>();
        typingStat = controllers.statController;

//		untypedText.text = "mhee ant bird cat dog elephant frog giraffe horse iguana jaguar kangaroo lion monkey " +
//						   "narwhal owl penguin quail rat snake turtle urial vulture whale xenathra yak zebra";
		wordSetLoader.LoadWord("test.txt");
		AddWord (40);
		typedText.text = " " + EncodeColor ("", correctColor);
	}
	
	// Update is called once per frame
	void Update () {
        HandleTypeInput();
	}

	void HandleTypeInput () {
		string input = Input.inputString;
		char c;
        if (running)
        {
            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                if (c == "\b"[0])
                {
                    TypedBackspace();
                }
                else if (c == ' ')
                {
                    TypedSpace();
                }
                else if (c == untypedText.text[0])
                {
                    TypedChar(c, true);
                }
                else
                {
                    TypedChar(c, false);
                }
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
            charCount--;
			if (wrongCount == 0) {
				text = ReplaceLastWord (text, EncodeColor (word, correctColor));
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
			text = ReplaceLastWord (text, EncodeColor (word, wrongColor));

			onWrongWord.Invoke ();
		}
		else {
            onCompleteWord.Invoke();
		}

        wrongCount = 0;
        charCount = 0;
		untypedText.text = untypedText.text.Remove (0, untypedText.text.IndexOf(' ') + 1);
		typedText.text = text.Insert (text.Length, " " + EncodeColor("", correctColor));

		if (--wordLeftCount <= 20) {
			AddWord (40);
		}
	}

	void TypedChar(char c, bool correct) {
		string text = typedText.text;
        charCount++;
        if (!correct) {
			if (wrongCount == 0) {
				string word = GetLastWord (text);
				text = ReplaceLastWord (text, EncodeColor (word, wrongColor));
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

	void AddWord(int n) {
		untypedText.text += string.Join(" ", wordSetGenerator.getRandomWords(40, wordSetLoader.GetWordPool()).ToArray()) + " ";
		wordLeftCount += n;
	}
}
