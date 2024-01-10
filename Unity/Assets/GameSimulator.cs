using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSimulator : MonoBehaviour
{
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
        }
        else
        {
            Debug.Log(team.fillAmount);
            loader.SetTrigger($"trigger{team.fillAmount * 10}");
            
            //team.fillAmount += 0.1f;
        }



    }
}