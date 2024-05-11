using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionNext : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        StateManager.Instance.SwitchToNextScenePrefab();
    }
}
