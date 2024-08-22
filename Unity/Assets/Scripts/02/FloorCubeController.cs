// FloorCubeScript.cs
using UnityEngine;

public class FloorCubeController : MonoBehaviour
{
    public GridSpace wallCube;

    public void UpdateWallCube()
    {
        wallCube.UpdateValue();
        gameObject.SetActive(false);
    }
}
