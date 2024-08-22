using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSimulatorController : MonoBehaviour
{
    [SerializeField] private VirusSpawner virusSpawner;
    [SerializeField] private DisplayWinners displayWinners;

    private bool hasShownWinners = false; // Flag to track if winners have been shown

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are winners and if winners haven't been shown yet
        if (LoaderManager.Instance.IsWinner().Length != 0 && !hasShownWinners)
        {
            // Stop spawning objects
            virusSpawner.StopSpawningObjects();

            // Show winners
            displayWinners.ShowWinners();

            // Destroy all viruses
            DestroyAllViruses();

            // Set flag to true so winners are not shown again
            hasShownWinners = true;
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
