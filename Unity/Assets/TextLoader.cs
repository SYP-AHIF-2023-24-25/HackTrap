using UnityEngine;
using UnityEngine.UI; // For Unity UI Text
// using TMPro; // Uncomment if using TextMeshPro

public class TextLoader : MonoBehaviour
{
    public Text loaderText; // For Unity UI Text
    // public TextMeshProUGUI loaderText; // Uncomment if using TextMeshPro
    public int maxBars = 7; // Number of bars to display
    public float updateInterval = 0.5f; // Time in seconds between updates

    private float progress = 0f;
    private float timer = 0f;
    private int currentBarCount = 0;
    private NewLoaderManager loaderManager;

    void Start()
    {
        loaderManager = FindObjectOfType<NewLoaderManager>();
        if (loaderManager != null)
        {
            loaderManager.RegisterLoader(this);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            timer = 0f;
            UpdateLoaderText();
        }
    }

    void UpdateLoaderText()
    {
        currentBarCount = Mathf.FloorToInt(progress * maxBars); // Calculate bars based on progress
        string bars = new string('|', currentBarCount); // Create the bar string
        loaderText.text = bars; // Update the text
    }

    public void SetProgress(float newProgress)
    {
        progress = Mathf.Clamp01(newProgress); // Ensure progress is between 0 and 1
        UpdateLoaderText(); // Update the text immediately
    }
}
