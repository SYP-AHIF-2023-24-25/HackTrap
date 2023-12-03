using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial color
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Change the color when clicked
            SetRandomColor();
        }
    }

    // Function to set a random color
    void SetRandomColor()
    {
        // Generate random color values
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        // Set the object's color
        GetComponent<Renderer>().material.color = new Color(r, g, b);
    }
}
