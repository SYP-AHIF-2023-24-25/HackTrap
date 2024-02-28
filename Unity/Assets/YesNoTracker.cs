using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class YesNoTracker : MonoBehaviour
{
    public ButtonAnimation noBtn;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "noBtn")
        {
            Debug.Log("Test");
            noBtn.PlayAnimation();
        }else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
