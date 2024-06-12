using System.Collections;
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
        for (int i = 0; i < teams.Length && teamIndex == 0; i++)
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
        //PlayerPrefs.SetInt("virusCounter", virusCounter);
        //PlayerPrefs.SetString("team", teamName);
        virusCounter = PlayerPrefs.GetInt("virusCounter");
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