using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinners : MonoBehaviour
{
    [SerializeField]
    private Text winnerText;

    // Dictionary to map team numbers to team color names
    private readonly Dictionary<string, string> teamColors = new Dictionary<string, string>
    {
        { "Team1", "Team Red" },
        { "Team2", "Team Green" },
        { "Team3", "Team Blue" },
        { "Team4", "Team Yellow" }
    };

    public void ShowWinners()
    {
        // Get the list of winners from the LoaderManager
        string[] winners = LoaderManager.Instance.IsWinner();

        // Check if there are any winners
        if (winners.Length != 0)
        {
            // Convert team numbers to team names
            for (int i = 0; i < winners.Length; i++)
            {
                if (teamColors.TryGetValue(winners[i], out string teamName))
                {
                    winners[i] = teamName;
                }
                else
                {
                    winners[i] = "Unknown Team"; // Optional: Handle unknown team numbers
                }
            }

            // Construct the winners string
            string winnersList = "The Winners are " + string.Join(", ", winners);

            // Set the Text component to display the winners
            winnerText.text = winnersList;

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
