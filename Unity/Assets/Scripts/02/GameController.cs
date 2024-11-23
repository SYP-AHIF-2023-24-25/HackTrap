using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to scene transition animator
    [SerializeField] private GameObject[] floorFields; // Floor fields for enabling/disabling
    [SerializeField] private Text[] buttonList; // UI buttons representing the grid
    //[SerializeField] private GameObject startTriggerFieldRed, startTriggerFieldBlue; // StartTriggerFields for players

    private static readonly int GRID_LENGTH = 3;
    private static readonly Color COLOR_O = Color.blue; // Color for 'O'
    private static readonly Color COLOR_X = Color.green; // Color for 'X'

    private string playerSide; // Player's current side ('X' or 'O')
    private string matchResult; // Result of the match

    private PlayerCounterController playerCounterController;
    private Player.Team currentTeam;
    private List<Player> players = new List<Player>();


    /*private void Update()
    {
        CheckPlayersOnTrigger();
    }*/

    private void Awake()
    {
        SetAllFloorCubesActive(false);

        SetGameControllerReferenceOnButtons();
        currentTeam = Player.Team.Green;
        playerSide = "X";

        playerCounterController = FindObjectOfType<PlayerCounterController>();
        players.AddRange(playerCounterController.GetAllPlayers());

        SetAllFloorCubesActiveForTeam(currentTeam);
    }

    // Set the GameController reference on each button's GridSpace component
    private void SetGameControllerReferenceOnButtons()
    {
        foreach (Text button in buttonList)
        {
            GridSpace gridSpace = button.GetComponentInParent<GridSpace>();
            gridSpace.SetGameControllerReference(this);
        }
    }

    // Returns the current player's color
    public Color GetColor()
    {
        return playerSide == "X" ? COLOR_X : COLOR_O;
    }

    // Returns the current player's symbol
    public string GetPlayer()
    {
        return playerSide;
    }

    // Switches the active player and triggers the computer's turn if necessary
    public void ChangePlayer()
    {
        currentTeam = currentTeam == Player.Team.Green ? Player.Team.Blue : Player.Team.Green;
        playerSide = currentTeam == Player.Team.Green ? "X" : "O";
        SetAllFloorCubesActiveForTeam(currentTeam);

        /*if (playerSide == "O")
        {
            SetAllFloorCubesActive(false);
            StartCoroutine(ComputerTurn());
        }*/
    }

    private int startTicTacToeCollider = 0;

    /*public void CheckPlayersOnTrigger()
    {
        Collider[] collidersRed = Physics.OverlapBox(startTriggerFieldRed.transform.position, startTriggerFieldRed.transform.localScale / 2);
        foreach (Collider collider in collidersRed)
        {
            Player player = collider.GetComponent<Player>();

            if (collider.CompareTag("DPlayer") && player.team == Player.Team.Red)
            {
                startTicTacToeCollider++;
                Debug.Log("Player red assigned.");
                break;
            }
        }

        Collider[] collidersBlue = Physics.OverlapBox(startTriggerFieldBlue.transform.position, startTriggerFieldBlue.transform.localScale / 2);
        foreach (Collider collider in collidersBlue)
        {
            Player player = collider.GetComponent<Player>();

            if (collider.CompareTag("DPlayer") && player.team == Player.Team.Blue)
            {
                startTicTacToeCollider++;
                Debug.Log("Player blue assigned.");
                break;
            }
        }

        if(startTicTacToeCollider == 2)
        {
            SetAllFloorCubesActive(true);
            startTriggerFieldBlue.SetActive(false);
            startTriggerFieldRed.SetActive(false);
        }
    }*/

    private void SetAllFloorCubesActiveForTeam(Player.Team currentTeam)
    {
        foreach (Player player in players)
        {
            if (player.team == currentTeam)
            {
                EnablePlayerTicTacToe(player, true);
            }
            else
            {
                EnablePlayerTicTacToe(player, false);
            }
        }

        SetAllFloorCubesActive(true);
    }

    private void EnablePlayerTicTacToe(Player player, bool isEnabled)
    {
        player.GetComponent<Collider>().enabled = isEnabled;
    }


    // Handles the computer's move using the Minimax algorithm
    /*private IEnumerator ComputerTurn()
    {
        yield return new WaitForSeconds(1f); // Delay before the computer moves

        int bestMove = Minimax(playerSide);
        buttonList[bestMove].text = playerSide;
        buttonList[bestMove].GetComponentInParent<Button>().interactable = false;

        SetAllFloorCubesActive(true);
        EndTurn();
    }*/

    // Activates/deactivates floor cubes based on the state of the game
    private void SetAllFloorCubesActive(bool isActive)
    {
        for (int i = 0; i < floorFields.Length; i++)
        {
            bool isButtonEmpty = buttonList[i].text == "";

            var parentObject = floorFields[i].transform.parent;
            var textComponent = parentObject.GetComponentInChildren<Text>();
            textComponent.text = buttonList[i].text;
            textComponent.color = buttonList[i].text == "X" ? COLOR_X : COLOR_O;

            floorFields[i].SetActive(isActive && isButtonEmpty);
        }
    }

    // Ends the current turn, checking for game over conditions
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

    // Handles game over state, disables interaction and triggers scene transition
    private void GameOver()
    {
        foreach (Text button in buttonList)
        {
            button.GetComponentInParent<Button>().interactable = false;
        }

        animator.SetTrigger("End");
        StartCoroutine(StateManager.Instance.SwitchSceneAfterAnimation(animator));
    }

    // Checks if a specific row is filled with one player's symbol
    private bool IsRowFilledWithOnePlayer(int row, string playerSymbol)
    {
        int startIndex = row * GRID_LENGTH;

        return buttonList[startIndex].text == playerSymbol &&
               buttonList[startIndex + 1].text == playerSymbol &&
               buttonList[startIndex + 2].text == playerSymbol;
    }

    // Checks if a specific column is filled with one player's symbol
    private bool IsColumnFilledWithOnePlayer(int column, string playerSymbol)
    {
        return buttonList[column].text == playerSymbol &&
               buttonList[column + GRID_LENGTH].text == playerSymbol &&
               buttonList[column + 2 * GRID_LENGTH].text == playerSymbol;
    }

    // Checks if either diagonal is filled with one player's symbol
    private bool IsDiagonalFilledWithOnePlayer(string playerSymbol)
    {
        return (buttonList[0].text == playerSymbol &&
                buttonList[4].text == playerSymbol &&
                buttonList[8].text == playerSymbol) ||
               (buttonList[2].text == playerSymbol &&
                buttonList[4].text == playerSymbol &&
                buttonList[6].text == playerSymbol);
    }

    // Minimax algorithm to determine the best move for the computer
    /*private int Minimax(string currentPlayer)
    {
        int bestScore = int.MinValue;
        int bestMove = -1;

        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text == "")
            {
                buttonList[i].text = currentPlayer; // Make the move
                int score = MinimaxScore(currentPlayer == "O" ? "X" : "O", false); // Get score
                buttonList[i].text = ""; // Undo the move

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        return bestMove;
    }

    // Recursive function to evaluate the score of the board
    private int MinimaxScore(string currentPlayer, bool isMaximizing)
    {
        if (IsGameOver("X"))
            return -1;
        if (IsGameOver("O"))
            return 1;
        if (IsTie())
            return 0;

        int bestScore = isMaximizing ? int.MinValue : int.MaxValue;

        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text == "")
            {
                buttonList[i].text = currentPlayer; // Make the move
                int score = MinimaxScore(currentPlayer == "O" ? "X" : "O", !isMaximizing);
                buttonList[i].text = ""; // Undo the move

                if (isMaximizing)
                {
                    bestScore = Mathf.Max(score, bestScore);
                }
                else
                {
                    bestScore = Mathf.Min(score, bestScore);
                }
            }
        }

        return bestScore;
    }
    */
    // Checks if the game is over for the given player
    private bool IsGameOver(string playerSymbol)
    {
        if (IsDiagonalFilledWithOnePlayer(playerSymbol))
        {
            matchResult = playerSymbol;
            PlayerPrefs.SetString("matchResult", matchResult);
            return true;
        }

        for (int gridPart = 0; gridPart < GRID_LENGTH; gridPart++)
        {
            if (IsRowFilledWithOnePlayer(gridPart, playerSymbol) ||
                IsColumnFilledWithOnePlayer(gridPart, playerSymbol))
            {
                matchResult = playerSymbol;
                PlayerPrefs.SetString("matchResult", matchResult);
                return true;
            }
        }

        return false;
    }

    // Checks if the game has ended in a tie
    private bool IsTie()
    {
        foreach (Text button in buttonList)
        {
            if (button.text == "")
            {
                return false;
            }
        }

        matchResult = "";
        PlayerPrefs.SetString("matchResult", matchResult);
        return true;
    }

    // Returns the result of the match
    public string GetWinner(string result)
    {
        switch (result)
        {
            case "O":
                return "TEAM BLUE WON!";
            case "X":
                return "TEAM GREEN WON!";
            default:
                return "DRAW!";
        }
    }
}
