using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene01 : MonoBehaviour
{

    public void SwitchScene()
    {
        StateManager.Instance.SwitchToNextScenePrefab();
    }
}
