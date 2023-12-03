using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;

    private void OnMouseDown()
    {
        // Check if the next scene name is not null or empty
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set. Please assign a scene name in the inspector.");
        }
    }
}
