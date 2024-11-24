using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamVirusCounter
{
    private static TeamVirusCounter _instance;
    public static TeamVirusCounter Instance 
    { 
        get
        {
            if (_instance == null)
            {
                _instance = new TeamVirusCounter();
            }
            return _instance;
        } 
    }

    private Dictionary<string, int> teamsVirusCounter;

    private TeamVirusCounter()
    {
        teamsVirusCounter = new Dictionary<string, int>();
        teamsVirusCounter.Add("TeamGreen", 0);
        teamsVirusCounter.Add("TeamBlue", 0);
    }


    // Public method to update the loader progress
    public void UpdateTeamCount(string teamName, int virusCountToAdd)
    {
        if (teamsVirusCounter.ContainsKey(teamName))
        {
            teamsVirusCounter[teamName] += virusCountToAdd;
            Debug.Log($"Updated {teamName} count to {teamsVirusCounter[teamName]}");

            //update specific team counter on wall
            Text teamCounter = GameObject.FindGameObjectWithTag("VirusCounter" + teamName).GetComponent<Text>();
            teamCounter.text = teamsVirusCounter[teamName].ToString();
        }
    }


    // Public method to get the current loader progress for a specific team
    public int GetTeamVirusCount(string teamName)
    {
        if (teamsVirusCounter.ContainsKey(teamName))
        {
            return teamsVirusCounter[teamName];
        }
        else
        {
            return -1;
        }
    }

    public string IsWinner()
    {
        string winningTeam = "Unentschieden";
        int maxCount = 0;
        bool isTie = false;

        foreach (var team in teamsVirusCounter)
        {
            if (team.Value > maxCount)
            {
                maxCount = team.Value;
                winningTeam = team.Key;
                isTie = false;
            }
            else if (team.Value == maxCount)
            {
                isTie = true;
            }
        }

        return isTie ? "Unentschieden" : winningTeam;
    }

}
