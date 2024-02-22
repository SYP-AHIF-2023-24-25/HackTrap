using DeepSpace.LaserTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{

    int persons;

    static bool IsInBox(float x, float y, float boxX, float boxY, float boxWidth, float boxHeight)
    {
        // Check if the point is within the bounds of the box
        if (x >= boxX && x < boxX + boxWidth && y >= boxY && y < boxY + boxHeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void receiveEvents(TrackRecord track)
    {
        Debug.Log("Received track record " + track.currentPos.ToString());

        if(IsInBox(track.currentPos.x, track.currentPos.y, -1800, 0, 800, 800))
        {
            Debug.Log("First box is being selected");
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, -900, 0, 800, 800))
        {
            Debug.Log("Second box is being selected");
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 0, 0, 800, 800))
        {
            Debug.Log("Third box is being selected");
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 900, 0, 800, 800))
        {
            Debug.Log("Fourth box is being selected");
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 1800, 0, 800, 800))
        {
            Debug.Log("Fifth box is being selected");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
