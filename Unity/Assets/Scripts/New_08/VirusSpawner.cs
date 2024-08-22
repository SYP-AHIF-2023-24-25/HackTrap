using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int maxNumberOfObjectsToSpawn;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 2f;
    [SerializeField] private Vector3 rotationAngles;
    [SerializeField] private string virusTag = "Virus";
    [SerializeField] private GameObject SpawnArea;

    private BoxCollider spawnAreaCollider;


    void Start()
    {
        spawnAreaCollider = SpawnArea.GetComponent<BoxCollider>();


        // Start spawning objects
        InvokeRepeating(nameof(SpawnObject), Random.Range(minSpawnDelay, maxSpawnDelay), Random.Range(minSpawnDelay, maxSpawnDelay));
        
    }

    void Update()
    {
        // Destroy objects outside bounds using collider bounds check
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(virusTag))
        {
            if (!spawnAreaCollider.bounds.Contains(obj.transform.localPosition))
            {
                Destroy(obj);
            }
        }
    }

    public void StopSpawningObjects()
    {
        // Stop spawning objects
        CancelInvoke(nameof(SpawnObject));
    }

    void SpawnObject()
    {
        if (GameObject.FindGameObjectsWithTag(virusTag).Length >= maxNumberOfObjectsToSpawn)
        {
            return;
        }

        Vector3 randomPosition = GetRandomPositionWithinBounds();

        // Instantiate the object at the random position
        GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.Euler(rotationAngles));

        var collider = spawnedObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = spawnedObject.transform.localScale;

        var rigidbody = spawnedObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        spawnedObject.tag = virusTag; // Ensure the spawned object is tagged appropriately

        VirusMovement virusMovement = spawnedObject.AddComponent<VirusMovement>();
        virusMovement.Initialize(spawnAreaCollider);
    }

    Vector3 GetRandomPositionWithinBounds()
    {
        Vector3 minBounds = spawnAreaCollider.bounds.min;
        Vector3 maxBounds = spawnAreaCollider.bounds.max;

        float midpointY = ((minBounds.y + maxBounds.y) / 2f);


        return new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            midpointY, // Assuming you want to spawn at the bottom of the collider
            Random.Range(minBounds.z, maxBounds.z)
        );
    }
}
