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
    private Context context;
    private bool wordAlreadySet = false;

    void Start()
    {
        _configMgr = CmdConfigManager.Instance as UdpCmdConfigMgr;
        context = GameObject.FindObjectOfType<Context>();

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
        if(!(string.IsNullOrEmpty(word)) && wordAlreadySet == false)
        {
            characterOne.GetComponent<Text>().text = word[0] + "";
            characterTwo.GetComponent<Text>().text = word[1] + "";
            characterThree.GetComponent<Text>().text = word[2] + "";
            characterFour.GetComponent<Text>().text = word[3] + "";
            characterFive.GetComponent<Text>().text = word[4] + "";
            Debug.Log("Floor Word: " + word);
            context.setShuffledWord(word);
            UdpSender udpSender = GameObject.Find("UdpSenderToWall").GetComponent<UdpSender>();

            if(udpSender != null)
            {
                Debug.Log("Sender to Wall da, schicke Nachricht");
                udpSender.AddMessage("thanksGotIt");
            }
            wordAlreadySet = true;
        }
    }
}
