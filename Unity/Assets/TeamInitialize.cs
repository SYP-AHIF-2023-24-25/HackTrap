using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColorChanger game = FindObjectOfType<ColorChanger>();
        game.InitializeTeams();
    }
}
