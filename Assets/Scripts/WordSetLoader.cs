using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordSetLoader : MonoBehaviour {
    List<string> WordPool = new List<string>();
    public List<string> LoadWord(string filename) // "filename.txt"
    {
        string[] lines = File.ReadAllLines("./Assets/"+filename);
        char[] delimiter = {' '};
        foreach(string line in lines)
        {
            string[] words = line.Split(delimiter);
            foreach(string word in words)
            {
                WordPool.Add(word);
            }
        }
        return WordPool;
    }
    public List<string> getWordPool()
    {
        return WordPool;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
