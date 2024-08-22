using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWithContainer1 : MonoBehaviour
{
    public Context contextScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Winner"))
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
        }
    }
}
