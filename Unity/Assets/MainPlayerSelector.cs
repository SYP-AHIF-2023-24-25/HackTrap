using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerSelector : MonoBehaviour
{
    public GameObject[] players; // Array to hold all player GameObjects
    public GameObject[] cubes; // Array to hold all cube GameObjects
    private GameObject currentMainPlayer; // Variable to hold the current main player
    private List<GameObject> availablePlayers = new List<GameObject>(); // List to hold available players

    void Start()
    {
        // Find all players with the "DPlayer" tag and add them to the availablePlayers list
        GameObject[] dPlayers = GameObject.FindGameObjectsWithTag("DPlayer");
        availablePlayers.AddRange(dPlayers);

        // Select a random main player from the available players
        SelectMainPlayer();
    }

    void Update()
    {
        // Check if the action is complete
        // You can define your conditions for completing the action here
        bool actionComplete = true; // For demonstration purposes, action is always considered complete

        if (actionComplete)
        {
            // Move the current main player back to their cube
            // You would need to implement your own method to move the player back

            // Select a new main player
            StartCoroutine(SelectMainPlayerWithDelay());
        }
    }

    IEnumerator SelectMainPlayerWithDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Select a new main player
        SelectMainPlayer();
    }

    void SelectMainPlayer()
    {
        // If there are no available players, return
        if (availablePlayers.Count == 0)
            return;

        // Select a random index from the available players
        int randomIndex = Random.Range(0, availablePlayers.Count);

        // Set the current main player to the randomly selected player
        currentMainPlayer = availablePlayers[randomIndex];

        // Remove the selected player from the available players list
        availablePlayers.RemoveAt(randomIndex);

        Debug.Log("Main Player: " + currentMainPlayer.name);

        // Change the color of the cube and the player
        ChangeColor(currentMainPlayer);
    }


    void ChangeColor(GameObject player)
    {
        // Find the cube that the player is standing on
        foreach (GameObject cube in cubes)
        {
            Collider[] colliders = Physics.OverlapBox(cube.transform.position, cube.transform.localScale / 2);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject == player)
                {
                    // Change color of the player
                    player.GetComponent<Renderer>().material.color = Color.red;
                    break; // No need to continue checking other cubes
                }
            }
        }
    }
}
