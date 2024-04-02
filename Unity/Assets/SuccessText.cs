using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessText : MonoBehaviour
{
    private Text messageText;

    string successText = "Success! ";

    private async void Awake()
    {
        messageText = transform.Find("SuccessMessage").GetComponent<Text>();
        Debug.Log(messageText);
    }

    private void Start()
    {
        TextWriter.AddWriterStatic(messageText, successText, .2f, false);
    }
}
