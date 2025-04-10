using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    private bool isOnTrigger = false;

    public bool IsOnTrigger(GameObject triggerField)
    {
        return isOnTrigger && triggerField != null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartTrigger"))
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StartTrigger"))
        {
            isOnTrigger = false;
        }
    }
}