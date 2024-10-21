using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    private Animator animator;  // Animator for triggering transitions

    [SerializeField]
    private Text textUI;  // UI Text component for displaying the text

    [SerializeField]
    private float letterDelay = 0.1f; // Delay between each letter being displayed

    [SerializeField]
    private float lineDelay = 0.5f;   // Delay after each line before moving to the next

    private GameController ticTacToeGameController; // Reference to the game controller for determining the winner

    [SerializeField]
    private int index = 0;  // Index used for scene switching
    [SerializeField]
    private bool switchScene = false;  // Whether to switch scenes after text is displayed


    [SerializeField]
    private int delayBeforeSwitch = 0;  // Delay in seconds before switching scenes

    [SerializeField]
    private string displayText = "Default Text";  // The text to display

    private string[] lines;  // Array of lines from the display text
    private int currentLineIndex = 0;  // Current line being displayed
    private int currentLetterIndex = 0;  // Current letter within the line being displayed
    private float letterTimer = 0f;  // Timer for letter delay
    private float lineTimer = 0f;  // Timer for line delay
    private bool isDisplayingText = false;  // Whether text is currently being displayed

    void Start()
    {
        // Check if the Text UI component is assigned
        if (textUI == null)
        {
            Debug.LogError("Text UI not assigned!");
            enabled = false;
            return;
        }

        // Get the display text from PlayerPrefs if available
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("WinnerText")))
        {
            displayText = PlayerPrefs.GetString("WinnerText");
        }
        else
        {
            // If no winner text is set, get it from the game controller
            if (string.IsNullOrEmpty(textUI.text))
            {
                string matchResult = PlayerPrefs.GetString("matchResult");
                ticTacToeGameController = FindObjectOfType<GameController>();
                displayText = ticTacToeGameController.GetWinner(matchResult);
            }
            else
            {
                displayText = textUI.text;
            }
        }

        // Split the text into lines and start displaying text
        lines = displayText.Split('\n');
        isDisplayingText = true;
        letterTimer = letterDelay;  // Initialize the letter timer
        lineTimer = lineDelay;  // Initialize the line timer
        textUI.text = ""; // Clear any existing text in the UI component
    }

    void Update()
    {
        if (isDisplayingText)
        {
            DisplayText();
        }
    }

    // Method to handle displaying text letter by letter and line by line
    private void DisplayText()
    {
        if (currentLineIndex < lines.Length)
        {
            string line = lines[currentLineIndex];

            // Display the current line letter by letter
            if (currentLetterIndex < line.Length)
            {
                letterTimer -= Time.deltaTime;
                if (letterTimer <= 0f)
                {
                    textUI.text = line.Substring(0, currentLetterIndex + 1); // Display text up to the current letter
                    currentLetterIndex++;
                    letterTimer = letterDelay;
                }
            }
            else
            {
                // Move to the next line after the delay
                lineTimer -= Time.deltaTime;
                if (lineTimer <= 0f)
                {
                    currentLineIndex++;
                    if (currentLineIndex < lines.Length)
                    {
                        // Reset letter index and timer for the new line
                        currentLetterIndex = 0;
                        letterTimer = letterDelay;
                        lineTimer = lineDelay;
                    }
                    else
                    {
                        // All lines have been displayed, handle scene switch
                        if(switchScene)
                        {
                            isDisplayingText = false;
                            HandleSceneSwitch();
                        }
                    }
                }
            }
        }
    }

    // Method to handle scene switching after text display is complete
    private void HandleSceneSwitch()
    {
        StartCoroutine(SwitchSceneAfterDelay());
    }

    // Coroutine to switch scenes after a specified delay
    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSwitch);

        if (index == 0)
        {
            animator.SetTrigger("End");
            yield return StateManager.Instance.SwitchSceneAfterAnimation(animator);
        }
        else
        {
            StateManager.Instance.SwitchToScenePrefab(index);
        }
    }
}
