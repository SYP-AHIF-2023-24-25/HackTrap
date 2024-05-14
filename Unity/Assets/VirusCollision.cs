using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets called when the object enters the collider area 
    void OnTriggerEnter(Collider objectName)
    {
        UnityEngine.Debug.Log("Entered collision with " + objectName.gameObject.name);
    }

    // Gets called during the stay of object inside the collider area
    void OnTriggerStay(Collider objectName)
    {
        UnityEngine.Debug.Log("Colliding with " + objectName.gameObject.name);
    }

    // Gets called when the object exits the collider area
    void OnTriggerExit(Collider objectName)
    {
        UnityEngine.Debug.Log("Exited collision with " + objectName.gameObject.name);
    }
}
