﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class WallUpdaterMain : MonoBehaviour
{

    public GameObject timer;

    public int timeout = 0;

    private int timeoutCounter = 0;

    private int timeoutCounterSecond = 0;

    public AudioSource timeoutSound;

    [SerializeField] private LoaderManager loaderManager;
    [SerializeField] private DisplayWinners displayWinners;
    [SerializeField] private VirusSpawner virusSpawner;


    void executeTimeout()
    {
        if (timeoutCounter >= timeout)
        {
            timeoutSound.Stop();
            string[] winners = loaderManager.IsWinner();
            PlayerPrefs.SetInt("gameOver", 1);

            if (winners.Length != 0)
            {
                displayWinners.ShowWinners();
                virusSpawner.StopSpawningObjects();
                DestroyAllViruses();
            }

            
        }
        else
        {
            timer.GetComponent<Text>().text = (timeout - timeoutCounter) < 10 ? " " + (timeout - timeoutCounter) : (timeout - timeoutCounter) + "";
            if (timeout - timeoutCounter < 11)
            {
                timer.GetComponent<Text>().color = Color.red;
                timeoutSound.Play();
            }
            timeoutCounter++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeoutCounter = 0;
        timeoutCounterSecond = DateTime.UtcNow.Second;
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.UtcNow.Second != timeoutCounterSecond)
        {
            executeTimeout();
            timeoutCounterSecond = DateTime.UtcNow.Second;
        }
    }

    public void DestroyAllViruses()
    {
        // Find all GameObjects with the tag "Virus"
        GameObject[] viruses = GameObject.FindGameObjectsWithTag("Virus");

        // Loop through the array and destroy each GameObject
        foreach (GameObject virus in viruses)
        {
            Destroy(virus);
        }
    }
}