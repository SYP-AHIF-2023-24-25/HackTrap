using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject circleObject;

    private MeshRenderer[] meshRenderers;

    void Start()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.z = 2f;
        gameObject.transform.position = newPosition;
    }


    void Update()
    {
        // Get input from keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the circleObject based on input and speed
        circleObject.transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        circleObject.transform.RotateAround(transform.position, Vector3.up, 25 * Time.deltaTime);

        // Ensure gameObject remains in the center of circleObject
        transform.position = circleObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Entered collision with " + gameObject.name);
    }
}
