using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionVirus : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Virus");
        CollisionManager.Instance.CollectVirus(this.gameObject);
    }
}
