using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSetGenerator {
    public System.Random rnd = new System.Random();
    /*public string getrandomword() //สุ่มคำจาก file test.txt 
    {
        List<string> set = LoadWord("test.txt");
        int i = rnd.Next(set.Count);
        return set[i];
    }*/
    
    public List<string> getRandomWords(int n, List<string> wordPool) //n - จำนวนคำ
    {
        List<string> set1 = wordPool;
        List<string> set2 = new List<string>();
        for (int i = 0; i < n; i++)
        {
            int j = rnd.Next(set1.Count);
            set2.Add(set1[j]);
        }
        return set2;
    }
}
