﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class ExplainGame : MonoBehaviour
{
    private Text explanationText;

    string explanation = "Eliminate the viruses by collecting them to your teambase on the corners \n You can collect a maximum of 5! \n Good luck! \n 3 \n 2 \n 1 ";

    private async void Awake()
    {
        explanationText = transform.Find("ExplanationText").GetComponent<Text>();
        Debug.Log(explanationText);
    }

    private void Start()
    {
        TextExplanation.AddWriterStatic(explanationText, explanation, .15f, false);
        //for (int countDown = 3; countDown > 0; countDown--)
        //{
        //   TextExplanation.AddWriterStatic(explanationText, countDown.ToString(), .15f, false);
        //}
        //Thread.Sleep(1000);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}