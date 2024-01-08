using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class WelcomeAnimation : MonoBehaviour
{
    private Text messageText;

    private GameController gameController;
    private string matchResult;

    string welcomeText = "Welcome to Deepspace! \n The game starts as soon as all players are on the floor. \n We hope you like it! Your HackTrap Team: Christian, Amina, Julian & Julia :) ";

    private async void Awake()
    {
        messageText = transform.Find("Message").Find("MessageText").GetComponent<Text>();
        Debug.Log(messageText);
        gameController = FindObjectOfType<GameController>();
        this.matchResult = gameController.GetWinner();
    }

    private void Start()
    {
        TextWriter.AddWriterStatic(messageText, this.matchResult, .15f, false);
    }
}
