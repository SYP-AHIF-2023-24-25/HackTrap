using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnSelection : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Animation duration
    [SerializeField] private float animationDuration = 0.5f;

    // Reference to the RawImage components
    [SerializeField] private RawImage wallMemoryImage;
    [SerializeField] private RawImage wallRPSImage;
    [SerializeField] private RawImage floorMemoryImage;
    [SerializeField] private RawImage floorRPSImage;
    [SerializeField] private Texture2D disabledSprite;

    // Flag to prevent animation overlap
    private bool isAnimating = false;

    [SerializeField] private AudioSource audioSource;

    private const int MAX_ITERATION = 1;
    private int[] iterationCounter = new int[2];

    public void StartAnimation(string field)
    {
        if (field == "TicTacToe" && !isAnimating)
        {
            animator.SetTrigger("End");
            StartCoroutine(StateManager.Instance.SwitchSceneAfterAnimation(animator));
        }
        else if (field == "RockPaperScissors" && !isAnimating && iterationCounter[0] < MAX_ITERATION)
        {
            // Start fade animation
            StartCoroutine(FadeAnimation(wallRPSImage));
            StartCoroutine(FadeAnimation(floorRPSImage));
            iterationCounter[0]++;
        }
        else if (field == "Memory" && !isAnimating && iterationCounter[1] < MAX_ITERATION)
        {
            // Start fade animation
            StartCoroutine(FadeAnimation(wallMemoryImage));
            StartCoroutine(FadeAnimation(floorMemoryImage));
            iterationCounter[1]++;
        }
    }


    IEnumerator FadeAnimation(RawImage rawImage)
    {
        audioSource.Play();
        isAnimating = true;

        // Fade out
        float elapsedTime = 0f;
        Color startColor = rawImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            rawImage.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        // Set texture and reset color
        rawImage.texture = disabledSprite;
        rawImage.color = startColor;

        isAnimating = false;
    }
}