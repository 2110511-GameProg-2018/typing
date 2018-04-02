using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordSetLoader : MonoBehaviour {
    
    public List<string> LoadWord(string filename) // "filename.txt"
    {
        List<string> set = new List<string> ();
        string[] lines = File.ReadAllLines("./Assets/"+filename);
        char[] delimiter = {' '};
        foreach(string line in lines)
        {
            string[] words = line.Split(delimiter);
            foreach(string word in words)
            {
                set.Add(word);
            }
        }
        return set;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
