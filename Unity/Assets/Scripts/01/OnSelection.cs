using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnSelection : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animationDuration = 0.5f;  // Duration for fade animation
    [SerializeField] private RawImage wallMemoryImage;
    [SerializeField] private RawImage wallRPSImage;
    [SerializeField] private RawImage floorMemoryImage;
    [SerializeField] private RawImage floorRPSImage;
    [SerializeField] private Texture2D disabledSprite;
    [SerializeField] private AudioSource audioSource;

    private const int MAX_ITERATION = 1;  // Max number of times an animation can play
    private bool isAnimating = false;  // Prevents overlapping animations
    private int[] iterationCounter = new int[2];  // Tracks how many times each animation has run

    // Starts the appropriate animation based on the selected field
    public void StartAnimation(string field)
    {
        if (isAnimating) return;  // Prevent starting new animations while one is running

        switch (field)
        {
            case "TicTacToe":
                animator.SetTrigger("End");
                StartCoroutine(StateManager.Instance.SwitchSceneAfterAnimation(animator));
                break;

            case "RockPaperScissors":
                if (iterationCounter[0] < MAX_ITERATION)
                {
                    StartCoroutine(FadeAnimation(wallRPSImage));
                    StartCoroutine(FadeAnimation(floorRPSImage));
                    iterationCounter[0]++;
                }
                break;

            case "Memory":
                if (iterationCounter[1] < MAX_ITERATION)
                {
                    StartCoroutine(FadeAnimation(wallMemoryImage));
                    StartCoroutine(FadeAnimation(floorMemoryImage));
                    iterationCounter[1]++;
                }
                break;
        }
    }

    // Coroutine to handle the fade-out animation
    private IEnumerator FadeAnimation(RawImage rawImage)
    {
        audioSource.Play();
        isAnimating = true;

        Color startColor = rawImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);  // Target fully transparent

        // Fade out over time
        for (float elapsedTime = 0f; elapsedTime < animationDuration; elapsedTime += Time.deltaTime)
        {
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            rawImage.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        // Reset image with disabled sprite and restore color
        rawImage.texture = disabledSprite;
        rawImage.color = startColor;

        isAnimating = false;
    }
}
