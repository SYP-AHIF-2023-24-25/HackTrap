using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    Vector3 randomDirection;

    void Start()
    {
        // Start moving in a random direction
        randomDirection = GetRandomDirection().normalized;
    }

    void Update()
    {
        // Move the object in the random direction
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Check if the object has moved outside the spawn area
        if (!GetComponent<Collider>().bounds.Contains(transform.position))
        {
            // Reverse the direction when reaching the boundary
            randomDirection = GetRandomDirection().normalized;
        }
    }

    Vector3 GetRandomDirection()
    {
        // Generate a random direction excluding downwards
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0f, 1f); // Excluding downwards
        float z = Random.Range(-1f, 1f);

        return new Vector3(x, 0, z);
    }
}
