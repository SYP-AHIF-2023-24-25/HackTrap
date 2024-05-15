using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAfterDelay : MonoBehaviour
{

    [SerializeField]
    private int sceneIndex = 0;

    [SerializeField]
    private float delay = 10f;

    [SerializeField]
    private Animator animator = null;


    void Start()
    {
        StartCoroutine(ExecuteAfterDelay(delay)); 
    }

    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetTrigger("End");
        StartCoroutine(StateManager.Instance.SwitchSceneAfterAnimation(animator));
    }


    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            StateManager.Instance.SwitchSceneAfterDelay(sceneIndex, delay);
        }

    }
}
