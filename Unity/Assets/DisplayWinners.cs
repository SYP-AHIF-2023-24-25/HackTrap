using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinners : MonoBehaviour
{
    [SerializeField]
    private Text winnerText;

    public void ShowWinners()
    {
        // Get the list of winners from the LoaderManager
        string winnerTeam = TeamVirusCounter.Instance.IsWinner();

        // Check if there are any winners
        if (!winnerTeam.Equals("Unentschieden"))
        {
            winnerText.text = "The Winners are " + winnerTeam;

            // Make sure the GameObject with this script is active
            GameObject.FindGameObjectWithTag("TeamLoader").SetActive(false);
            this.gameObject.SetActive(true);
        }
        else
        {
            // Optionally handle the case where there are no winners
            winnerText.text = "No winners this time!";
            this.gameObject.SetActive(true);
        }
    }
}
