using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PointerMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the speed of movement

    // Define boundary coordinates
    float leftBoundary = 0f;
    float rightBoundary = 3200f;
    float topBoundary = 200f;
    float bottomBoundary = -200f; // Assuming the bottom boundary is below y=0
    float width = 1450f;
    float height = 2400f;

    // Update is called once per frame
    void Update()
    {
        // Get input from ASDF keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        UnityEngine.Debug.Log("Horizontal Input: " + horizontalInput);
        UnityEngine.Debug.Log("Vertical Input: " + verticalInput);

        // Calculate movement direction
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the GameObject in 2D space
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        Vector3 pointerPosition = transform.position;

        UnityEngine.Debug.Log("X: " + pointerPosition.x);
        UnityEngine.Debug.Log("Y: " + pointerPosition.y);
        UnityEngine.Debug.Log("Z: " + pointerPosition.z);

        // Check if the pointer is within the specified boundaries
        // Check if the pointer is within the specified boundaries
        
        if (pointerPosition.x >= leftBoundary && pointerPosition.x <= (leftBoundary + width) &&
            pointerPosition.y >= bottomBoundary && pointerPosition.y <= (bottomBoundary + height))
        {
            UnityEngine.Debug.Log("Pointer is within the specified region.");
        }
    }
}