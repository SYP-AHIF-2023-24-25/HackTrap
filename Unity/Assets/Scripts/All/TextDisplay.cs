using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text textUI;

    [SerializeField]
    private float letterDelay = 0.1f; // Delay between each letter

    [SerializeField]
    private float lineDelay = 0.5f;   // Delay after each line

    private GameController ticTacToeGameController;

    [SerializeField]
    private bool isSwitch = true;

    [SerializeField]
    private int index = 0;

    [SerializeField]
    private int delayBeforeSwitch = 0;

    [SerializeField]
    private string displayText = "Default Text";


    private string[] lines;
    private string currentLine = "";
    private int currentLineIndex = 0;
    private int currentLetterIndex = 0;
    private float letterTimer = 0f;
    private float lineTimer = 0f;
    private bool isDisplayingText = false;

    void Start()
    {
        if (textUI == null)
        {
            //Debug.LogError("Text UI not assigned!");
            enabled = false;
        }

        if (PlayerPrefs.GetString("WinnerText") != "")
        {
            displayText = PlayerPrefs.GetString("WinnerText");
        }
        else
        {
            if (textUI.text == "" || textUI.text == null)
            {
                var matchResult = PlayerPrefs.GetString("matchResult");
                ticTacToeGameController = FindObjectOfType<GameController>();
                displayText = ticTacToeGameController.GetWinner(matchResult);
            }
            else
            {
                displayText = textUI.text;
            }

        }

        lines = displayText.Split('\n');
        isDisplayingText = true;
    }

    void Update()
    {
        if (isDisplayingText)
        {
            if (currentLineIndex < lines.Length)
            {
                string line = lines[currentLineIndex];

                if (currentLetterIndex < line.Length)
                {
                    letterTimer -= Time.deltaTime;
                    if (letterTimer <= 0f)
                    {
                        currentLine += line[currentLetterIndex];
                        textUI.text = currentLine;
                        currentLetterIndex++;
                        letterTimer = letterDelay;
                    }
                }
                else
                {
                    lineTimer -= Time.deltaTime;
                    if (lineTimer <= 0f)
                    {
                        currentLineIndex++;
                        if (currentLineIndex < lines.Length) // Check if there are more lines
                        {
                            currentLetterIndex = 0;
                            currentLine = "";
                            lineTimer = lineDelay;
                        }
                        else // No more lines, stop displaying text
                        {
                            isDisplayingText = false;

                            if (isSwitch)
                            {
                                
                                Thread.Sleep(delayBeforeSwitch * 1000);

                                if (index == 0)
                                {
                                    animator.SetTrigger("End");
                                    StartCoroutine(StateManager.Instance.SwitchSceneAfterAnimation(animator));
            
                                }
                                else
                                {
                                    StateManager.Instance.SwitchToScenePrefab(index);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    
}
