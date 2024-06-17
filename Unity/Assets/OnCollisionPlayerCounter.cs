using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class OnCollisionPlayerCounter : MonoBehaviour
{
    // Variable zur Speicherung der Anzahl der Spieler im Bereich
    public Text playerCountTextField;
    private int playerCount = 0;
    private static List<GameObject> players = new List<GameObject>();
    private bool playerExist = false;
    public int timeout;
    private int timeoutCounter = 0;
    public GameObject timer;
    private int timeoutCounterSecond = 0;
    public AudioSource timeoutSound;
    private int switchOnes = 0;

    // Methode, die aufgerufen wird, wenn ein Spieler den Collider betritt
    void OnTriggerEnter(Collider other)
    {
        foreach(GameObject player in players)
        {
            if(player.name == other.name)
            {
                playerExist = true;
            }
        }
        if(!playerExist)
        {
            players.Add(other.gameObject);
            playerCount++;
            playerExist = false;
            timeout = 15;
            timeoutCounter = 0;
            timer.GetComponent<Text>().color = Color.white;
            Debug.Log("Spieler betreten den Bereich. Anzahl: " + playerCount);
            UpdatePlayerCountText();
        }
    }
    void UpdatePlayerCountText()
    {
        // Aktualisiere den Text, um die aktuelle Spieleranzahl anzuzeigen
        playerCountTextField.text = "PLayers on field: " + playerCount;
    }

    public List<List<GameObject>> DividePlayersIntoTeams()
    {
        // Erstelle eine Liste mit vier Teams
        List<List<GameObject>> teams = new List<List<GameObject>>()
        {
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>()
        };
        // Teile die Spieler gleichmäßig auf die vier Teams auf
        for (int i = 0; i < players.Count; i++)
        {
            teams[i % 4].Add(players[i]);
        }

        return teams;
    }

    private void Start()
    {
        timeoutCounter = 0;
        timeoutCounterSecond = DateTime.UtcNow.Second;
    }
    private void Update()
    {
        if(switchOnes < 1)
        {
            if (DateTime.UtcNow.Second != timeoutCounterSecond)
            {
                executeTimeout();
                timeoutCounterSecond = DateTime.UtcNow.Second;
            }
        }
    }
    void executeTimeout()
    {
        if (timeoutCounter >= timeout)
        {
            switchOnes++;
            StateManager.Instance.SwitchToNextScenePrefab();
        }
        else
        {
            timer.GetComponent<Text>().text = (timeout - timeoutCounter) < 10 ? " " + (timeout - timeoutCounter) : (timeout - timeoutCounter) + "";
            if (timeout - timeoutCounter < 5)
            {
                timer.GetComponent<Text>().color = Color.red;
                timeoutSound.Play();
            }
            timeoutCounter++;
        }
    }
}
