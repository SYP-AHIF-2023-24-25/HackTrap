using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NoTracker : MonoBehaviour
{
    
    public ButtonAnimation noBtn;

    void OnTriggerEnter(Collider other)
    {
        noBtn.PlayAnimation();
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Code here will execute after the delay
        StateManager.Instance.SwitchToNextScenePrefab();
    }

    
}
