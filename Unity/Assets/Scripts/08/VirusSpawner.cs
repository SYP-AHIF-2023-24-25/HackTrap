using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnAreaSize;
    public int numberOfObjectsToSpawn;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Collider spawnAreaCollider = GetComponent<Collider>();
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Generate random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(transform.position.x - spawnAreaSize.x / 2, transform.position.x + spawnAreaSize.x / 2),
                Random.Range(transform.position.y - spawnAreaSize.y / 2, transform.position.y + spawnAreaSize.y / 2),
                Random.Range(transform.position.z - spawnAreaSize.z / 2, transform.position.z + spawnAreaSize.z / 2)
            );

            // Check if the random position is inside the spawn area
            if (spawnAreaCollider.bounds.Contains(randomPosition))
            {
                // Spawn the object at the random position
                Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            }
        }
    }
}
