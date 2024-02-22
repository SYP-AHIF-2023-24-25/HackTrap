using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitchSim : MonoBehaviour
{
    public float delayInSeconds = 5f; // Adjust the delay time as needed
    public string sceneName = "";

    void Start()
    {
        // Start the coroutine
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Change the scene by loading a new scene
        // Replace "SceneName" with the name of your target scene
        SceneManager.LoadScene(sceneName);
    }
}
