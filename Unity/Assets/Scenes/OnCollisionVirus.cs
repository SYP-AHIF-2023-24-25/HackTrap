using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionVirus : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Virus");
        this.gameObject.SetActive(false);
        CollisionManager collision = new CollisionManager();
        collision.CollectVirus();
    }
}
