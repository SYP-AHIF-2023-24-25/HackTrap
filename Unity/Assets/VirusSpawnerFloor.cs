using DeepSpace.Udp;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using DeepSpace;

public class VirusSpawnerFloor : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private string virusTag = "Virus";
    [SerializeField] private GameObject SpawnArea;
    private UdpReceiver udpReceiver; // UDP Receiver für Netzwerkkommunikation

    private BoxCollider spawnAreaCollider;
    private UdpCmdConfigMgr _configMgr;


    void Start()
    {
        _configMgr = CmdConfigManager.Instance as UdpCmdConfigMgr;

        if (_configMgr.applicationType == CmdConfigManager.AppType.FLOOR) { 
            spawnAreaCollider = SpawnArea.GetComponent<BoxCollider>();

            udpReceiver = GameObject.Find("UdpReceiver").GetComponent<UdpReceiver>();
            udpReceiver.SubscribeReceiveEvent(OnReceiveVirusData);
        }
    }

    void OnReceiveVirusData(byte[] messageBytes, IPAddress senderIP)
    {
        string jsonData = System.Text.Encoding.UTF8.GetString(messageBytes);
        Debug.Log($"Daten Länge JsonData: {jsonData.Length} und Message: {messageBytes.Length}");
        Debug.Log($"Daten von Wall: {jsonData}");
        VirusData virusData = JsonUtility.FromJson<VirusData>(jsonData);

        SpawnVirus(virusData.Position, virusData.Rotation, virusData.Movement);
    }
    public void StopSpawningObjects()
    {
        // Stop spawning objects
        CancelInvoke(nameof(SpawnVirus));
    }

    void SpawnVirus(Vector3 position, Vector3 rotation, Vector3 movement)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, position, Quaternion.Euler(rotation));

        var collider = spawnedObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = spawnedObject.transform.localScale;

        var rigidbody = spawnedObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        spawnedObject.tag = virusTag; // Ensure the spawned object is tagged appropriately
        VirusMovement virusMovement = spawnedObject.AddComponent<VirusMovement>();
        virusMovement.Initialize(spawnAreaCollider);
        virusMovement.randomDirection = movement;
    }
    void Update()
    {
        if (_configMgr.applicationType == CmdConfigManager.AppType.FLOOR)
        {
            // Destroy objects outside bounds using collider bounds check
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(virusTag))
            {
                if (!spawnAreaCollider.bounds.Contains(obj.transform.localPosition))
                {
                    Debug.Log("Virus außerhalb Spawnarea gelöscht");
                    Destroy(obj);
                }
            }
        }
    }

    [System.Serializable]
    private class VirusData
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Movement;
    }
}
