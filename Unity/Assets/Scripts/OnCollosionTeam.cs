using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OnCollosionTeam : MonoBehaviour
{
    private int virusCounter = 0;
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Entered collision with " + gameObject.name);
        //CollisionManager.Instance.ResetVirusCounter();
    }
}
