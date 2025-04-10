using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamZoneManager : MonoBehaviour
{
    public static TeamZoneManager Instance;

    [SerializeField] private GameObject startButton;

    private PlayerCounterController playerCounterController;

    private List<Player> allPlayers = new List<Player>();

    void Start()
    {
        Instance = this;

        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        playerCounterController = FindObjectOfType<PlayerCounterController>();
        allPlayers.AddRange(playerCounterController.GetAllPlayersForStartScene());
    }

    void Update()
    {
        var allPlayersForNow = playerCounterController.GetAllPlayersForStartScene();
        if(allPlayersForNow.Count != allPlayers.Count)
        {
            allPlayers.Clear();
            Debug.Log("neue Players: " + allPlayers.Count);

            allPlayers.AddRange(playerCounterController.GetAllPlayersForStartScene());
        }
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
        Debug.Log(startButton);
        if (startButton == null)
        {
            Debug.Log("Switch scene");
            StateManager.Instance.SwitchToNextScenePrefab();
        }
        else
        {
            Debug.Log("enable button");
            startButton.SetActive(true);
        }
    }
}
