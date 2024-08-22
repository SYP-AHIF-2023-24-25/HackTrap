using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoaderManager : MonoBehaviour
{
    // Singleton instance
    public static LoaderManager Instance { get; private set; }
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
        loaderProgress = new float[4];
        for (int i = 0; i < loaderProgress.Length; i++)
        {
            loaderProgress[i] = 0f;
        }
    }


    // Public method to update the loader progress
    public void UpdateLoaderProgress(int teamIndex, float progress, float duration)
    {
        if (teamIndex >= 0 && teamIndex < loaderProgress.Length)
        {
            loaderProgress[teamIndex] = progress;
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

    public string[] IsWinner()
    {
        List<string> winnerTeams = new List<string>();
        float highestScore = float.MinValue;

        for (int i = 0; i < loaderProgress.Length; i++)
        {
            if (loaderProgress[i] > highestScore)
            {
                // Found a new highest score, clear the list and update the highest score
                highestScore = loaderProgress[i];
                winnerTeams.Clear();
                winnerTeams.Add("Team" + (i + 1));
            }
            else if (loaderProgress[i] == highestScore)
            {
                // Found another team with the same highest score
                winnerTeams.Add("Team" + (i + 1));
            }
        }

        return winnerTeams.ToArray();
    }


}
