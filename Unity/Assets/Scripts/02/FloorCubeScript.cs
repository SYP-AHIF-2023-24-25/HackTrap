// FloorCubeScript.cs
using UnityEngine;

public class FloorCubeScript : MonoBehaviour
{
    public GridSpace wallCube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DPlayer"))
        {
            //gameObject.SetActive(false); //disable grid space on floor
            wallCube.UpdateValue();
        }
    }


}
