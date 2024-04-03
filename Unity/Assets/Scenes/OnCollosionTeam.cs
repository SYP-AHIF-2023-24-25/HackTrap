using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollosionTeam : MonoBehaviour
{
    private int virusCounter = 0;
    void OnTriggerEnter(Collider other)
    {
         virusCounter = 0;
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetInt("virusCubeCounter", virusCounter);
    }
}
