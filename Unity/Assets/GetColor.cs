using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColor : MonoBehaviour
{
    private PlayerCounterController playerCounterController;

    private void Start()
    {
        playerCounterController = FindObjectOfType<PlayerCounterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DPlayer"))
        {
            playerCounterController.AssignPlayerToTeam(other.gameObject);
        }
    }
}
