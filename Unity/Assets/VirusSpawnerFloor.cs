using DeepSpace.Udp;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class VirusSpawnerFloor : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private string virusTag = "Virus";
    [SerializeField] private GameObject SpawnArea;
    [SerializeField] private UdpReceiver udpReceiver; // UDP Receiver für Netzwerkkommunikation

    private BoxCollider spawnAreaCollider;

    void Start()
    {
        spawnAreaCollider = SpawnArea.GetComponent<BoxCollider>();
        udpReceiver.SubscribeReceiveEvent(OnReceiveVirusData);
    }

    void OnReceiveVirusData(byte[] messageBytes, IPAddress senderIP)
    {
        string jsonData = System.Text.Encoding.UTF8.GetString(messageBytes);
        VirusData virusData = JsonUtility.FromJson<VirusData>(jsonData);

        SpawnVirus(virusData.Position, virusData.Rotation);
    }

    void SpawnVirus(Vector3 position, Vector3 rotation)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, position, Quaternion.Euler(rotation));

        var collider = spawnedObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = spawnedObject.transform.localScale;

        var rigidbody = spawnedObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        spawnedObject.tag = virusTag; // Ensure the spawned object is tagged appropriately
    }

    [System.Serializable]
    private class VirusData
    {
        public Vector3 Position;
        public Vector3 Rotation;
    }
}
