using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoaderManager : MonoBehaviour
{
    // Singleton instance
    public static LoaderManager Instance { get; private set; }

    [SerializeField] private Image[] loaderImages;
    private float[] loaderProgress;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy the new instance if one already exists
            return;
        }

        // Set the instance to this instance
        Instance = this;

        // Optionally, make the instance persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        loaderProgress = new float[loaderImages.Length];
        for (int i = 0; i < loaderProgress.Length; i++)
        {
            loaderProgress[i] = 0f;
            loaderImages[i].fillAmount = 0f;
        }
    }


    void Update()
    {
        IsWinner();
        UpdateAllLoaders();
    }


    // Public method to update the loader progress
    public void UpdateLoaderProgress(int teamIndex, float progress, float duration)
    {
        if (teamIndex >= 0 && teamIndex < loaderProgress.Length)
        {
            StartCoroutine(UpdateLoaderCoroutine(teamIndex, progress, duration));
            UpdateAllLoaders();
        }
    }

    private void UpdateAllLoaders()
    {
        for (int i = 0; i < loaderProgress.Length; i++)
        {
            loaderImages[i].fillAmount = loaderProgress[i];
        }
    }


    // Public method to get the current loader progress for a specific team
    public float GetCurrentLoaderProgress(int teamIndex)
    {
        if (teamIndex >= 0 && teamIndex < loaderProgress.Length)
        {
            return loaderProgress[teamIndex];
        }
        else
        {
            Debug.LogError("Invalid team index!");
            return -1f;  // Return an invalid value to indicate an error
        }
    }

    // Private coroutine to handle the smooth update of the loader progress
    private IEnumerator UpdateLoaderCoroutine(int teamIndex, float targetProgress, float duration)
    {
        float startProgress = loaderProgress[teamIndex];
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            loaderProgress[teamIndex] = Mathf.Lerp(startProgress, targetProgress, t);
            loaderImages[teamIndex].fillAmount = loaderProgress[teamIndex];
            yield return null;
        }

        loaderProgress[teamIndex] = targetProgress;
        loaderImages[teamIndex].fillAmount = loaderProgress[teamIndex];
    }


    public string[] IsWinner()
    {
        List<string> winnerTeams = new List<string>();

        for (int i = 0; i < loaderProgress.Length; i++)
        {
            if (loaderProgress[i] >= 1f)
            {
                winnerTeams.Add("Team" + (i + 1));  // Assuming team names are "Team 0", "Team 1", etc.
            }
        }

        return winnerTeams.ToArray();
    }
}
