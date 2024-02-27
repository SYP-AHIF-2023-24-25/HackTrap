using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public static List<FieldController> AllFields = new List<FieldController>();
    public GameObject[] players; // Array to hold all player GameObjects
    private GameObject currentMainPlayer; // Variable to hold the current main player
    private List<GameObject> availablePlayers = new List<GameObject>(); // List to hold available players


    private void Start()
    {
        AllFields.Add(this); // Add this field to the list of all fields
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a player
        if (other.CompareTag("DPlayer"))
        {
            // Set this field as the main player field

            SetMainPlayerField();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to a player
        if (other.CompareTag("DPlayer"))
        {
            // If the player exits the field, you might want to reset or do something else
        }
    }

    private void SetMainPlayerField()
    {
        // Choose a random field among all available fields
        int randomIndex = Random.Range(0, AllFields.Count);
        FieldController mainField = AllFields[randomIndex];

        // You might want to notify other scripts or do something specific with the main field
        Debug.Log(mainField.gameObject.name + " is now the main player field.");
    }
}