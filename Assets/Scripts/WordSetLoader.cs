using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordSetLoader {
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
    public List<string> GetWordPool()
    {
        return WordPool;
    }
}
