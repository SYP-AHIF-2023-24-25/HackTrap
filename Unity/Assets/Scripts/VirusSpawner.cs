using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner: MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnAreaSize;
    public int maxNumberOfObjectsToSpawn;

    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;

    void Start()
    {
        // Start the spawning process
        InvokeRepeating("SpawnObject", Random.Range(minSpawnDelay, maxSpawnDelay), Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void SpawnObject()
    {
        Collider spawnAreaCollider = GetComponent<Collider>();

        // Check if the maximum number of objects to spawn has been reached
        if (GameObject.FindGameObjectsWithTag("SpawnedObject").Length >= maxNumberOfObjectsToSpawn)
        {
            return;
        }

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
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            // Add movement script to the spawned object
            spawnedObject.AddComponent<ObjectMovement>();
        }
    }
}

