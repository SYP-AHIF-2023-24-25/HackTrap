﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static int GRID_LENGTH = 3;
    private static Color COLOR_O = Color.HSVToRGB(198, 0, 0); //red
    private static Color COLOR_X = Color.HSVToRGB(34, 113, 231); //blue

    public Text[] buttonList;
    private string playerSide;
    private int turn;

    public void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    public Color GetColor()
    {
        return playerSide == "X" ? Color.red : Color.blue;
    }

    public void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSpace currentGridSpace = buttonList[i].GetComponentInParent<GridSpace>();
            currentGridSpace.SetGameControllerReference(this);
        }
    }

    public string GetPlayer()
    {
        return playerSide;
    }

    public void ChangePlayer()
    {
        playerSide = playerSide == "X" ? "O" : "X";

        if (playerSide == "O") // Computer's turn
        {
            StartCoroutine(ComputerTurn());
        }
    }

    private IEnumerator ComputerTurn()
    {
        
        yield return new WaitForSeconds(1f); //delay

        // minimax algorithm for computer's move
        int bestMove = Minimax(playerSide);
        buttonList[bestMove].text = playerSide;
        buttonList[bestMove].GetComponentInParent<Button>().interactable = false;

        EndTurn();
    }

    public void EndTurn()
    {
        if (IsTie() || IsGameOver(playerSide))
        {
            GameOver(); 
        }
        else
        {
            ChangePlayer();
        }
    }

    public void GameOver()
    {
        //disable all buttons
        for (int i = 0; i < buttonList.Length; i++)
        {
            Button currentButton = buttonList[i].GetComponentInParent<Button>();
            currentButton.interactable = false;
        }

        //TODO: switch scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private bool IsRowFilledWithOnePlayer(int row, string playerSymbol)
    {
        int startIndex = row * 3;

        // Check if all buttons in the specified row have the player's symbol
        return buttonList[startIndex].text == playerSymbol &&
               buttonList[startIndex + 1].text == playerSymbol &&
               buttonList[startIndex + 2].text == playerSymbol;
    }

    private bool IsColumnFilledWithOnePlayer(int column, string playerSymbol)
    {
        return buttonList[column].text == playerSymbol &&
               buttonList[column + 3].text == playerSymbol &&
               buttonList[column + 6].text == playerSymbol;
    }

    private bool IsDiagonalFilledWithOnePlayer(string playerSymbol)
    {
        return (buttonList[0].text == playerSymbol &&
                buttonList[4].text == playerSymbol &&
                buttonList[8].text == playerSymbol) ||
               (buttonList[2].text == playerSymbol &&
                buttonList[4].text == playerSymbol &&
                buttonList[6].text == playerSymbol);
    }

    // Minimax algorithm for computer's move
    private int Minimax(string currentPlayer)
    {
        int bestScore = int.MinValue;
        int bestMove = -1;

        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text == "")
            {
                buttonList[i].text = currentPlayer;
                int score = MinimaxScore(currentPlayer, false);
                buttonList[i].text = ""; // undo the move

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }
        return bestMove;
    }

    private int MinimaxScore(string currentPlayer, bool isMaximizing)
    {
        if (IsGameOver("X"))
            return -1;

        if (IsGameOver("O"))
            return 1;

        if (IsTie())
            return 0;

        int score = isMaximizing ? int.MinValue : int.MaxValue;

        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text == "")
            {
                buttonList[i].text = currentPlayer;

                if (isMaximizing)
                {
                    score = Mathf.Max(score, MinimaxScore("O", !isMaximizing));
                }
                else
                {
                    score = Mathf.Min(score, MinimaxScore("X", !isMaximizing));
                }

                buttonList[i].text = ""; // undo the move
            }
        }
        return score;
    }

    //check rows, columns and diagonals
    private bool IsGameOver(string playerSymbol)
    {
        if (IsDiagonalFilledWithOnePlayer(playerSymbol))
            return true;

        for (int gridPart = 0; gridPart < GRID_LENGTH; gridPart++)
        {
            if (IsRowFilledWithOnePlayer(gridPart, playerSymbol)
                || IsColumnFilledWithOnePlayer(gridPart, playerSymbol))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsTie()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text == "")
            {
                return false;
            }
        }
        return true;
    }


    public string GetWinner(string result)
    {
        if (result == "O")
        {
            return "YOU LOST! ";
        }
        else if (result == "X")
        {
            return "YOU WON! ";
        }
        return "DRAW! ";
    }
}