using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTimer : MonoBehaviour
{
    public int timeout = 0;
    public int sceneIndex;

    private int timeoutCounterSecond = 0;
    void Start()
    {
        timeoutCounterSecond = DateTime.UtcNow.Second + timeout;
    }
    void Update()
    {
        Debug.Log("Scene Changer running");
        if (DateTime.UtcNow.Second >= timeoutCounterSecond)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
