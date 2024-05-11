using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField]
    private Text textUI;
    
    [SerializeField]
    private float letterDelay = 0.1f; // Delay between each letter

    [SerializeField]
    public float lineDelay = 0.5f;   // Delay after each line

    
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
            Debug.LogError("Text UI not assigned!");
            enabled = false;
            return;
        }

        displayText = textUI.text;
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
                        currentLetterIndex = 0;
                        currentLine = "";
                        lineTimer = lineDelay;
                    }
                }
            }
            else
            {
                isDisplayingText = false;
                Debug.Log("Text Display Complete");
            }
        }
    }
}
