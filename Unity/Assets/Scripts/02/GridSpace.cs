using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void UpdateValue()
    {
        Debug.Log("Field Updated");

        if(button.interactable)
        {
            buttonText.text = gameController.GetPlayer();
            buttonText.color = gameController.GetColor();
            button.interactable = false;
            gameController.EndTurn();
        }
    }
}
