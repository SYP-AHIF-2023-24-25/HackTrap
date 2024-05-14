using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject virusPrefabs;
    [SerializeField] private bool canSpawn = true;
    public Vector3 spawnAreaSize;
    public Vector3 rotationAngles;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            Vector3 randomPosition = new Vector3(
            Random.Range(transform.position.x - spawnAreaSize.x / 2, transform.position.x + spawnAreaSize.x / 2),
            -1.7f,
            Random.Range(transform.position.z - spawnAreaSize.z / 2, transform.position.z + spawnAreaSize.z / 2)
            );
            Instantiate(virusPrefabs, transform.position, Quaternion.identity);
        }

    }
}
