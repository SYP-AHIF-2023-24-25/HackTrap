using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfeilSceneManager : MonoBehaviour
{
    public static PfeilSceneManager Instance;

    private PlayerCounterController playerCounterController;

    private List<Player> allPlayers = new List<Player>();

    void Start()
    {
        Instance = this;
        playerCounterController = FindObjectOfType<PlayerCounterController>();
        allPlayers.AddRange(playerCounterController.GetAllPlayers());
    }

    public void CheckIfAllPlayersAreOnCorrectField()
    {
        foreach (Player player in allPlayers)
        {
            Debug.Log($"Spieler von Team {player.team} auf korrektem Teamfeld: {player.IsOnCorrectField()}");
            if (!player.IsOnCorrectField())
            {
                Debug.Log("Nicht alle auf korrektem Teamfeld!");
                return;
            }
        }

        Debug.Log("Alle auf korrektem Teamfeld!");
        StateManager.Instance.SwitchToNextScenePrefab();

    }
}
