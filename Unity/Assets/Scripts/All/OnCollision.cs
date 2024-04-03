using DeepSpace.LaserTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}