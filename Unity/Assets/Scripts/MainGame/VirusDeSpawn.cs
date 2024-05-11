using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusDeSpawn : MonoBehaviour
{
    public GameObject virus;
    public Text cubeTextField;

    private int counter = 0;
    public void Trigger()
    {
        if (PlayerPrefs.GetInt("virusCounter") == 1)
        {
            if(counter < 4)
            {
                virus.SetActive(false); 
                counter++;
                PlayerPrefs.SetInt("virusCubeCounter", counter);
            }
        }
    }
}
