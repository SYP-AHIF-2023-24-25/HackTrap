using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerChoiceController : MonoBehaviour
{
    [SerializeField] private Context contextScript;
    private TriggerFieldDelay triggerFieldDelay;

    void Awake()
    {
        // Initialize the component reference in Awake()
        triggerFieldDelay = GetComponent<TriggerFieldDelay>();

        // Optional: Check if the component is attached
        if (triggerFieldDelay == null)
        {
            Debug.LogError("TriggerFieldDelay component not found on this GameObject.");
        }
    }

    public void ChooseContainer()
    {
        if (PlayerPrefs.GetString("tag") == "Winner")
        {
            if (gameObject.CompareTag("Container1"))
            {
                contextScript.OnCollisionWithContainer1();
            }
            else if (gameObject.CompareTag("Container2"))
            {
                contextScript.OnCollisionWithContainer2();
            }
            else if (gameObject.CompareTag("Container3"))
            {
                contextScript.OnCollisionWithContainer3();
            }
            else if (gameObject.CompareTag("Container4"))
            {
                contextScript.OnCollisionWithContainer4();
            }
            else if (gameObject.CompareTag("Container5"))
            {
                contextScript.OnCollisionWithContainer5();
            }

            triggerFieldDelay.EnableAllContainers();
        }
    }
}
