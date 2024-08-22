using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
    [SerializeField] private string parameter;
    [SerializeField] private OnSelection scriptReference;


    public void PlayAnimation()
    {
        if (!string.IsNullOrEmpty(parameter) && scriptReference != null)
        {
            scriptReference.StartAnimation(parameter);
        }
    }
}
