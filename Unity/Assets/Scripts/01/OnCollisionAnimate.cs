using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAnimate : MonoBehaviour
{

    [SerializeField] private string parameter;
    [SerializeField] private OnSelection scriptReference;


    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(parameter) && scriptReference != null)
        {
            scriptReference.StartAnimation(parameter);
        }
    }

}
