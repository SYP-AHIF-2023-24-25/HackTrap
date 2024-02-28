using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallUpdateScript : MonoBehaviour
{

    public GameObject characterOne;
    public GameObject characterTwo;
    public GameObject characterThree;
    public GameObject characterFour;
    public GameObject characterFive;

    public GameObject timer;

    public int timeout = 0;

    private int timeoutCounter = 0;

    private int timeoutCounterSecond = 0;

    public AudioSource timeoutSound;
    public AudioSource backgroundAudio;


    public void updateCharacter(int index, char character)
    {
        if (index == 0)
        {
            characterOne.GetComponent<Text>().text = character + "";
        }
        if (index == 1)
        {
            characterTwo.GetComponent<Text>().text = character + "";
        }
        if (index == 2)
        {
            characterThree.GetComponent<Text>().text = character + "";
        }
        if (index == 3)
        {
            characterFour.GetComponent<Text>().text = character + "";
        }
        if (index == 4)
        {
            characterFive.GetComponent<Text>().text = character + "";
        }
    }

    void executeTimeout()
    {
        if (timeoutCounter >= timeout)
            SceneManager.LoadScene(14);
        else
        {
            timer.GetComponent<Text>().text = (timeout - timeoutCounter) < 10 ? " " + (timeout - timeoutCounter) : (timeout - timeoutCounter) + "";
            if(timeout - timeoutCounter < 11)
            {
                timer.GetComponent<Text>().color = Color.red;
                timeoutSound.Play();
                //backgroundAudio.Stop();
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
}
