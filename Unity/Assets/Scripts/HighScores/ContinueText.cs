using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueText : MonoBehaviour
{
    private Text messageText;

    string continueText = "Contiue text is comminggggggggg ";

    private async void Awake()
    {
        messageText = transform.Find("ContinueTeamText").Find("Text").GetComponent<Text>();
        Debug.Log(messageText);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("writeContinueText") == 1)
        {
            TextWriter.AddWriterStatic(messageText, continueText, .15f, false);
        }
    }

}
