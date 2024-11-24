using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallUpdaterTrialScript : MonoBehaviour
{
    public GameObject characterOne;
    public GameObject characterTwo;
    public GameObject characterThree;
    public GameObject characterFour;
    public GameObject characterFive;

    public GameObject timer;


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
}
