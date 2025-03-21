using DeepSpace;
using DeepSpace.Udp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGenerator : MonoBehaviour
{
    public string text = "VIRUS";

    public GameObject characterOne;
    public GameObject characterTwo;
    public GameObject characterThree;
    public GameObject characterFour;
    public GameObject characterFive;
    private UdpSender udpSender;
    private UdpCmdConfigMgr _configMgr;

    public Context context;

    public List<string> words = new List<string>
    {

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

    struct WordWrapper
    {
        public string word;
    }

    void Start()
    {
        _configMgr = CmdConfigManager.Instance as UdpCmdConfigMgr;
        Debug.Log("Start");
        if (_configMgr.applicationType == CmdConfigManager.AppType.WALL)
        {
            System.Random random = new System.Random();
            int index = random.Next(0, words.Count);

            string word = words[index];

            context.setCorrectWord(word);
            word = ShuffleString(word);
            udpSender = GameObject.Find("UdpSenderToFloor").GetComponent<UdpSender>();
            context.setShuffledWord(word);
            WordWrapper ww = new WordWrapper();
            ww.word = word;
            Debug.Log("Wall word: " + word);
            string jsonData = JsonUtility.ToJson(ww);
            Debug.Log("JsonData Wall: " + jsonData);
            udpSender.AddMessage(jsonData); // Position per UDP senden
            characterOne.GetComponent<Text>().text = word[0] + "";
            characterTwo.GetComponent<Text>().text = word[1] + "";
            characterThree.GetComponent<Text>().text = word[2] + "";
            characterFour.GetComponent<Text>().text = word[3] + "";
            characterFive.GetComponent<Text>().text = word[4] + "";


            Debug.Log(word);
        }

    }

    public void updateCharacter(int index, char character)
    {
        if(index == 0)
        {
            characterOne.GetComponent<Text>().text = character + "";
        }
        if (index == 1)
        {
            characterTwo.GetComponent<Text>().text = character + "";
        }
        if (index == 2)
        {
            characterThree.GetComponent<Text>().text = character + "";
        }
        if (index == 3)
        {
            characterFour.GetComponent<Text>().text = character + "";
        }
        if (index == 4)
        {
            characterFive.GetComponent<Text>().text = character + "";
        }
    }

    void Update()
    {
        
    }
}
