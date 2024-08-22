using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColor : MonoBehaviour
{
    [SerializeField] private PlayerCounterController playerCounterController;


    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DPlayer"))
        {
            playerCounterController.AssignPlayerToTeam(other.gameObject);
        }
    }
}
