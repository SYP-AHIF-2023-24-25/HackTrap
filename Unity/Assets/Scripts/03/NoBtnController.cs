using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBtnController : MonoBehaviour
{
    public ButtonAnimation noBtn;

    public void PlayAnimation()
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
