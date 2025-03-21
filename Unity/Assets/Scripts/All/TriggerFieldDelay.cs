using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class TriggerFieldDelay : MonoBehaviour
{
    [SerializeField]
    private float activationDelay = 2f; // Delay time before activation
    [SerializeField]
    private UnityEvent onTriggerEvent; // Event to trigger after delay

    private bool isCoroutineRunning = false; // To prevent multiple coroutines from running simultaneously

    private List<GameObject> disabledGameObjects = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DPlayer") && !isCoroutineRunning)
        {
            // Start the delay timer when the player enters the trigger
            PlayerPrefs.SetString("tag", other.gameObject.tag);
            StartCoroutine(ActivateTriggerAfterDelay());
        }

        if (other.CompareTag("Winner") && !isCoroutineRunning)
        {
            // Get the tag of the current GameObject
            string currentTag = gameObject.tag;

            // Find all GameObjects in the scene
            GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allGameObjects)
            {
                // Check if the tag starts with "Container" and is not the current GameObject
                if (obj.tag.StartsWith("Container") && obj != gameObject)
                {
                    // Store the GameObject in the list before disabling it
                    if (obj.activeSelf)
                    {
                        disabledGameObjects.Add(obj);
                    }

                    // Disable the GameObject
                    obj.SetActive(false);
                }
            }


            PlayerPrefs.SetString("tag", other.gameObject.tag);
            StartCoroutine(ActivateTriggerAfterDelay());
        }
    }

    public void EnableAllContainers()
    {

        // Iterate through the list of disabled GameObjects and re-enable them
        foreach (GameObject obj in disabledGameObjects)
        {
            if (obj != null) // Check if the GameObject still exists
            {
                obj.SetActive(true);
            }
        }

        // Clear the list after re-enabling
        disabledGameObjects.Clear();
        
    }


    IEnumerator ActivateTriggerAfterDelay()
    {
        isCoroutineRunning = true; // Mark the coroutine as running

        // Wait for the specified delay time
        yield return new WaitForSeconds(activationDelay);

        // Trigger the assigned event after the delay
        onTriggerEvent?.Invoke();

        isCoroutineRunning = false; // Allow the coroutine to be triggered again if needed
    }
}
