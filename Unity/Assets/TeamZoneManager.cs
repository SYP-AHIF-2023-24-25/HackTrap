﻿using System.Collections;
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
        if(startButton is null)
        {
            StateManager.Instance.SwitchToNextScenePrefab();
        }
        else
        {
            startButton.SetActive(true);
        }
        Debug.Log("Alle da");
    }
}