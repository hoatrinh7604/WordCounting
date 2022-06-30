using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordCount : MonoBehaviour
{
    public int Count(string phrase)
    {
        string[] source = phrase.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        var matchQuery = from word in source
                         select word;

        int wordCount = matchQuery.Count();

        return wordCount;
    }    
}
