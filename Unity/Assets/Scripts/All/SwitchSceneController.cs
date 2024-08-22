using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneController : MonoBehaviour
{

    public void SwitchScene()
    {
        StateManager.Instance.SwitchToNextScenePrefab();
    }
}
