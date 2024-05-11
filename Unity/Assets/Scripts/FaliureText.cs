using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaliureText : MonoBehaviour
{
    private Text messageText;

    string failureText = "Game over ";

    private async void Awake()
    {
        messageText = transform.Find("FailureMessage").GetComponent<Text>();
        Debug.Log(messageText);
    }

    private void Start()
    {
        //TextWriter.AddWriterStatic(messageText, failureText, .15f, false);
    }
}
