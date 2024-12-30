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
    private List<GameObject> playerObjects = new List<GameObject>();

    private List<Player> players = new List<Player>();

    private Dictionary<string, List<GameObject>> teams = new Dictionary<string, List<GameObject>>()
    {
        { "Green", new List<GameObject>() },
        { "Blue", new List<GameObject>() },
    };

    void Start()
    {
        PlayerPrefs.SetInt("gameOver", 0);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DPlayer") && !playerObjects.Contains(other.gameObject))
        {
            playerObjects.Add(other.gameObject);
            playerCount++;
            AssignPlayerToTeam(other.gameObject);
        }
        
        //wenn maingame fertig ist
        /*if (StateManager.Instance.GetCurrentIndex() > 8 && !other.gameObject.CompareTag("DPlayer"))
        {
            other.tag = "Winner";
        }*/
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DPlayer") && !playerObjects.Contains(other.gameObject))
        {
            playerObjects.Add(other.gameObject);
            playerCount++;
            AssignPlayerToTeam(other.gameObject);
        }
    }
    */


    public void InitializeTeamColor(GameObject playerObject)
    {
        List<List<GameObject>> teams = GetTeams();
        Debug.Log(teams.Count);
        for (int i = 0; i < teams.Count; i++)
        {
            foreach (GameObject playerObj in teams[i])
            {
                MeshRenderer[] currentMeshRenderers = playerObj.GetComponentsInChildren<MeshRenderer>();
                currentMeshRenderers[1].material.color = teamsColor[i];
            }
            //player.tag = "Team" + (i + 1);  -> später ändern für MainGame
        }
    }


    public void AssignPlayerToTeam(GameObject playerObject)
    {
        var smallestTeam = teams
            .OrderBy(team => team.Value.Count) 
            .First();
        var smallestTeamList = smallestTeam.Value;
        smallestTeamList.Add(playerObject);

        Player player = playerObject.GetComponent<Player>();
        Debug.Log("New player to add:" + player);
        player.team = (Player.Team)Enum.Parse(typeof(Player.Team), smallestTeam.Key);
        players.Add(player);
        Debug.Log("Added player");

        Debug.Log($"Playerobjects: {playerObjects.Count}");
        Debug.Log($"Team 0: {teams["Green"].Count}");
        Debug.Log($"Team 1: {teams["Blue"].Count}");
        Debug.Log($"Players: {players.Count}");

        InitializeTeamColor(playerObject);
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

    public List<Player> GetAllPlayers()
    {
        foreach (Player player in players)
        {
            player.GetComponent<Collider>().enabled = true;
            player.SetOnCorrectField(false);
        }

        return players;
    }

    public List<List<GameObject>> GetTeams()
    {
        return teams.Select(t => t.Value).ToList();
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
