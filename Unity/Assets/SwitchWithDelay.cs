using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWithDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoSomething());
    }

    private IEnumerator DoSomething()
    {
        // doing something

        // waits 5 seconds
        yield return new WaitForSeconds(5);

        // do something else
    }
}
