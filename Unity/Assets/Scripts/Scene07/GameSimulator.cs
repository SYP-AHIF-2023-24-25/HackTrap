using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSimulator : MonoBehaviour
{
    private Team[] teams;
    public Image Team1;
    public Image Team2;
    public Image Team3;
    public Image Team4;

    public Animator loader1;
    public Animator loader2;
    public Animator loader3;
    public Animator loader4;


    private bool winner = false;

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
        StartCoroutine(ExecuteFunctionAfterRandomTime());
    }

    IEnumerator ExecuteFunctionAfterRandomTime()
    {
        // Generate a random time between 1 and 4 seconds

        for (int i = 0; i < 40 && !winner;  i++)
        {
            float randomTime = Random.Range(1f, 4f);

            // Choose a random team between Team1 and Team4
            Image[] teams = { Team1, Team2, Team3, Team4 };
            Animator[] animators = { loader1, loader2, loader3, loader4 };

            int index = Random.Range(0, teams.Length);
            Image randomTeam = teams[index];
            this.teams[index].IncreaseScore();
            Animator loader = animators[index];

            // Wait for the random time
            yield return new WaitForSeconds(randomTime);

            // Execute the function with the chosen team
            MyFunction(randomTeam, loader);
        }

    }


    void MyFunction(Image team, Animator loader)
    {
       
        Debug.Log($"Executing function on {team.name}");


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
            Thread.Sleep(3000);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log(team.fillAmount);
            loader.SetTrigger($"trigger{team.fillAmount * 10}");
            
            //team.fillAmount += 0.1f;
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
}