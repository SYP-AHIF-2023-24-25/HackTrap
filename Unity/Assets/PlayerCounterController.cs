using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerCounterController : MonoBehaviour
{
    [SerializeField] private Text playerCountTextField;
    [SerializeField] private GameObject timer;
    [SerializeField] private AudioSource timeoutSound;
    [SerializeField] private int timeout = 15;
    [SerializeField] private Color[] teamsColor;



    private int playerCount = 0;
    private List<GameObject> players = new List<GameObject>();
    

    private List<List<GameObject>> teams = new List<List<GameObject>>()
    {
        new List<GameObject>(),
        new List<GameObject>(),
        new List<GameObject>(),
        new List<GameObject>()
    };

    void Start()
    {
        PlayerPrefs.SetInt("gameOver", 0);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DPlayer") && !players.Contains(other.gameObject))
        {
            if (StateManager.Instance.GetCurrentIndex() == 6 || StateManager.Instance.GetCurrentIndex() == 7)
            { 
                players.Add(other.gameObject);
                playerCount++;
                AssignPlayerToTeam(other.gameObject);
            }
        }

        if (StateManager.Instance.GetCurrentIndex() > 7 && !other.gameObject.CompareTag("DPlayer"))
        {
            other.tag = "Winner";
        }
    }


    public void InitializeTeams()
    {

        List<List<GameObject>> teams = GetTeams();
            for (int i = 0; i < teams.Count; i++)
            {
                foreach (GameObject player in teams[i])
                {
                    MeshRenderer[] currentMeshRenderers = player.GetComponentsInChildren<MeshRenderer>();
                    currentMeshRenderers[1].material.color = teamsColor[i];
                    player.tag = "Team" + (i + 1);
            }
            }
    }


    public void AssignPlayerToTeam(GameObject player)
    {
        // Find the team with the least number of members
        if (true)
        {
            List<GameObject> smallestTeam = teams.OrderBy(t => t.Count).First();
            smallestTeam.Add(player);
            player.name = smallestTeam[0].name;
            InitializeTeams();
        }
    }

    /*
    private void ResetTimeout()
    {
        timeoutCounter = 0;
        timer.GetComponent<Text>().color = Color.white;
    }

    private void UpdatePlayerCountText()
    {
        playerCountTextField.text = "Players on field: " + playerCount;
    }
    */

    public List<List<GameObject>> GetTeams()
    {
        return teams;
    }

    /*
    private void ExecuteTimeout()
    {
        if (StateManager.Instance.GetCurrentIndex() == 6)
        {
            if (timeoutCounter >= timeout)
            {
                switchOnes++;
                StateManager.Instance.SwitchToNextScenePrefab();
            }
            else
            {
                UpdateTimer();
                timeoutCounter++;
            }
        }
    }

    private void UpdateTimer()
    {
        int timeRemaining = timeout - timeoutCounter;
        timer.GetComponent<Text>().text = timeRemaining < 10 ? " " + timeRemaining : timeRemaining.ToString();

        if (timeRemaining < 5)
        {
            timer.GetComponent<Text>().color = Color.red;
            timeoutSound.Play();
        }
    }
    */
}
