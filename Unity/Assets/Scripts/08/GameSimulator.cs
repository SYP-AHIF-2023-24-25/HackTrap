﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSimulator : MonoBehaviour
{
    private Team[] teams;

    [SerializeField]
    private Image Team1;

    [SerializeField]
    private Image Team2;

    [SerializeField]
    private Image Team3;

    [SerializeField]
    private Image Team4;

    [SerializeField]
    private Animator loader1;

    [SerializeField]
    private Animator loader2;

    [SerializeField]
    private Animator loader3;

    [SerializeField]
    private Animator loader4;


    private bool winner = false;
    string changeToRightTeam = "";
    int teamIndex = 0;
    int virusCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        teams = new Team[]
        {
            new Team("GREEN"),
            new Team("ORANGE"),
            new Team("PINK"),
            new Team("BLUE")
        };
    }

    public void ExecuteFunctionAfterRandomTime()
    {
        changeToRightTeam = PlayerPrefs.GetString("team");
        Image[] teams = { Team1, Team2, Team3, Team4 };
        Animator[] animators = { loader1, loader2, loader3, loader4 };
        for (int i = 0; i < teams.Length; i++)
        {
            if(changeToRightTeam.Equals(teams[i].name))
            {
                teamIndex = i;
                MyFunction(teams[teamIndex], animators[teamIndex]);
            }
        }
    }

    void MyFunction(Image team, Animator loader)
    {
        virusCounter = PlayerPrefs.GetInt("virusCounter");
        loader.SetTrigger($"trigger{team.fillAmount * 10}");
        if (team.fillAmount == 1)
        {
            winner = true;

            //save fillamout of teams
            PlayerPrefs.SetInt("teams_count", this.teams.Length);

            for (int i = 0; i < this.teams.Length; i++)
            {
                PlayerPrefs.SetInt("team_" + i, this.teams[i].virusScore);
                PlayerPrefs.SetString("team_" + i + "_name", this.teams[i].name);
            }

            //Scene Switch
            Thread.Sleep(1000);
            StateManager.Instance.SwitchToNextScenePrefab();
            
        }
    }


    public class Team
    {
        public string name;
        public int virusScore;

        public Team(string name)
        {
            this.name = name;
            this.virusScore = 0;
        }

        public void IncreaseScore()
        {
            this.virusScore++;
        }
        
        public void DecreaseScore()
        {
            this.virusScore--;
        }
    }

    public void ResetColours()
    {
        // Find all GameObjects with the tag "Dplayer"
        GameObject[] dplayerObjects = GameObject.FindGameObjectsWithTag("Dplayer");

        // Iterate through each object found
        foreach (GameObject obj in dplayerObjects)
        {
            // Get all MeshRenderer components attached to the GameObject
            MeshRenderer[] meshRenderers = obj.GetComponentsInChildren<MeshRenderer>();

            // Loop through each MeshRenderer starting from index 2
            for (int x = 2; x < meshRenderers.Length; x++)
            {
                UnityEngine.Debug.Log("Resetting colors");
                meshRenderers[x].material.color = Color.white;
            }
        }
    }
}