using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGenerator : MonoBehaviour
{
    public GameObject canvasPrefab;
    public string text = "VIRUS";

    public GameObject characterOne;
    public GameObject characterTwo;
    public GameObject characterThree;
    public GameObject characterFour;
    public GameObject characterFive;

    List<string> words = new List<string>
    {
        "VIRUS",
        "CLICK",
        "CRYPT",
        "PHISH",
        "CYBER"
    };


    private string ShuffleString(string word)
    {
        char[] chars = word.ToCharArray();
        int len = chars.Length;

        System.Random random = new System.Random();

        while(len > 1)
        {
            len--;

            int ran = random.Next(len + 1);

            char tempChar = chars[ran];

            chars[ran] = chars[len];
            chars[len] = tempChar;
        }

        return new string(chars);
    }


    void Start()
    {
        Debug.Log("Start");
        System.Random random = new System.Random();
        int index = random.Next(0, words.Count);

        string word = words[index];

        word = ShuffleString(word);


        characterOne.GetComponent<Text>().text = word[0] + "";
        characterTwo.GetComponent<Text>().text = word[1] + "";
        characterThree.GetComponent<Text>().text = word[2] + "";
        characterFour.GetComponent<Text>().text = word[3] + "";
        characterFive.GetComponent<Text>().text = word[4] + "";


        Debug.Log(word);
    }

    void Update()
    {
        
    }
}
