using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanPlayerAndField : MonoBehaviour
{
    private MeshRenderer[] meshRenderers;
    private MainPlayerController mainPlayerController;
    // Start is called before the first frame update
    void Start()
    {
        mainPlayerController = FindObjectOfType<MainPlayerController>();
        mainPlayerController.ResetColors();
        DestroyAllViruses();
    }
    public void DestroyAllViruses()
    {
        // Find all GameObjects with the tag "Virus"
        GameObject[] viruses = GameObject.FindGameObjectsWithTag("Virus");

        // Loop through the array and destroy each GameObject
        foreach (GameObject virus in viruses)
        {
            Destroy(virus.gameObject);
        }
        GameObject[] virusesWithoutGameobject = GameObject.FindGameObjectsWithTag("Virus");
        if(virusesWithoutGameobject != null)
        {
            foreach (GameObject virus in virusesWithoutGameobject)
            {
                Destroy(virus);
            }
        }
    }
}
