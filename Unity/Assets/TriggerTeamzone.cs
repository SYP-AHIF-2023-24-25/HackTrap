using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeamzone : MonoBehaviour
{
    public Player.Team expectedTeam;

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        Debug.Log($"Player vom Team {player.team} entered Teamzone {expectedTeam}");

        if (player != null && player.team == expectedTeam)
        {
            player.SetOnCorrectField(true);
            Debug.Log($"Player auf korrekter Teamzone");
            TeamZoneManager.Instance.CheckIfAllPlayersAreOnCorrectField();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        Debug.Log($"Player vom Team {player.team} exited Teamzone {expectedTeam}");

        if (player != null && player.team == expectedTeam)
        {
            player.SetOnCorrectField(false);
            Debug.Log($"Player nicht mehr auf Teamzone");
            TeamZoneManager.Instance.CheckIfAllPlayersAreOnCorrectField();
        }
    }
}
