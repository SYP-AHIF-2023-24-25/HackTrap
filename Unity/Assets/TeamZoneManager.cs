using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamZoneManager : MonoBehaviour
{
    public static TeamZoneManager Instance;

    [SerializeField] public GameObject startButton;
    [SerializeField] public bool switchScene;

    private PlayerCounterController playerCounterController;

    private List<Player> allPlayers = new List<Player>();

    void Start()
    {
        Instance = this;
        startButton.SetActive(false);

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
        startButton.SetActive(true);

        Debug.Log("Alle da");
        if(switchScene)
        {
            StateManager.Instance.SwitchToNextScenePrefab();
        }
    }
}
