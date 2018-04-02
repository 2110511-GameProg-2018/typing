using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSet : MonoBehaviour {
    List<string> Words = new List<string>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public List<string> getWords()
    {
        return Words;
    }
    public List<string> merge(WordSet a,WordSet b)
    {
        List<string> set1 = a.getWords();
        List<string> set2 = b.getWords();
        set1.AddRange(set2);
        return set1;
    }
}
