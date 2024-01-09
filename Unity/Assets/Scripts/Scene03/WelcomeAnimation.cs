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
    private string matchresult;
    private string result;

    private async void Awake()
    {
        messageText = transform.Find("matchresult").GetComponent<Text>();
        Debug.Log(messageText);
        gameController = FindObjectOfType<GameController>();
        this.matchresult = PlayerPrefs.GetString("matchResult");
        this.result = gameController.GetWinner(this.matchresult);
    }

    private void Start()
    {
        TextWriter.AddWriterStatic(messageText, this.result, .15f, false);
    }
}
