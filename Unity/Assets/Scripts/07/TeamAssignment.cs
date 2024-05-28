using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class TeamAssignment : MonoBehaviour
{
    private Text teamAssignment;

    string assignmentText = "If you want to get your data back\n Split into teams of four! ";

    private async void Awake()
    {
        teamAssignment = transform.Find("TeamAssignment").GetComponent<Text>();
        Debug.Log(teamAssignment);
    }

    private void Start()
    {
        //TextWriter.AddWriterStatic(teamAssignment, assignmentText, .15f, false);
    }
}
