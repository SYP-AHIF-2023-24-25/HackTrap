using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeamzone : MonoBehaviour
{
    public Player.Team expectedTeam;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Player player = other.GetComponent<Player>();
        if (player != null && player.team == expectedTeam)
        {
            player.SetOnCorrectField(true);
            TeamZoneManager.Instance.CheckIfAllPlayersAreOnCorrectField();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");

        Player player = other.GetComponent<Player>();
        if (player != null && player.team == expectedTeam)
        {
            player.SetOnCorrectField(false);
            TeamZoneManager.Instance.CheckIfAllPlayersAreOnCorrectField();
        }
    }
}
