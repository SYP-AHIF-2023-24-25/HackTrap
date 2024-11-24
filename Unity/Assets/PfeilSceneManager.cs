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
            if (!player.IsOnCorrectField())
            {
                return;
            }
        }

        Debug.Log("Alle da");
        StateManager.Instance.SwitchToNextScenePrefab();
    }
}
