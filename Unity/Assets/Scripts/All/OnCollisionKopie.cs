using DeepSpace.LaserTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnCollisionKopie : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision - Skip to next scene");

        // Do something if tracker collides with this object
        StateManager.Instance.SwitchToNextScenePrefab();

    }
}