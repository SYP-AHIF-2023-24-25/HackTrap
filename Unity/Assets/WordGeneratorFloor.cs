using DeepSpace;
using DeepSpace.Udp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class WordGeneratorFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject characterOne;
    public GameObject characterTwo;
    public GameObject characterThree;
    public GameObject characterFour;
    public GameObject characterFive;
    private UdpReceiver udpReceiver;
    private UdpCmdConfigMgr _configMgr;

    void Start()
    {
        _configMgr = CmdConfigManager.Instance as UdpCmdConfigMgr;

        if (_configMgr.applicationType == CmdConfigManager.AppType.FLOOR)
        {
            udpReceiver = GameObject.Find("UdpReceiver").GetComponent<UdpReceiver>();
            udpReceiver.SubscribeReceiveEvent(OnReceiveWordData);
        }
    }
    struct WordWrapper
    {
        public string word;
    }
    private void OnReceiveWordData(byte[] messageBytes, IPAddress senderIP)
    {
        string jsonData = System.Text.Encoding.UTF8.GetString(messageBytes);
        WordWrapper ww = JsonUtility.FromJson<WordWrapper>(jsonData);
        string word = ww.word;
        Debug.Log("JsonData FLoor: " + jsonData);
        Debug.Log("Floor Word: " + word);

        characterOne.GetComponent<Text>().text = word[0] + "";
        characterTwo.GetComponent<Text>().text = word[1] + "";
        characterThree.GetComponent<Text>().text = word[2] + "";
        characterFour.GetComponent<Text>().text = word[3] + "";
        characterFive.GetComponent<Text>().text = word[4] + "";
    }

    public void updateCharacter(int index, char character)
    {
        if (index == 0)
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
