using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OnCollisionPlayerCounter : MonoBehaviour
{
    // Variable zur Speicherung der Anzahl der Spieler im Bereich
    public Text playerCountTextField;
    private int playerCount = 0;
    private List<GameObject> players = new List<GameObject>();
    private bool playerExist = false;

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

            if (playerCount == 4)
            {
                StateManager.Instance.SwitchToNextScenePrefab();
            }
            Debug.Log("Spieler betreten den Bereich. Anzahl: " + playerCount);
            UpdatePlayerCountText();
        }
    }
    void UpdatePlayerCountText()
    {
        // Aktualisiere den Text, um die aktuelle Spieleranzahl anzuzeigen
        playerCountTextField.text = "PLayers on field: " + playerCount;
    }

    public List<List<GameObject>> DividePlayersIntoTeams(List<GameObject> players)
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
}
