using DeepSpace.LaserTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{

    int persons;
    long charSelectTime;
    char character;

    string correctWord;
    string shuffledWord;

    public WordGenerator wordGenerator;



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

    public void setCorrectWord(string word)
    {
        Debug.Log(word + " set as correct word");
        correctWord = word;
    }

    public void setShuffledWord(string word)
    {
        Debug.Log(word + " set as shuffled word");

        shuffledWord = word;
    }


    public void receiveEvents(TrackRecord track)
    {
        //Debug.Log("Received track record X: " + track.currentPos.x + " Y: " + track.currentPos);

        if(IsInBox(track.currentPos.x, track.currentPos.y, 3200, 300, 800, 800))
        {
            Debug.Log("First box is being selected " + shuffledWord[0]);
            if(!character.Equals('1'))
            {
                charSelectTime = DateTime.UtcNow.Second;
                character = '1';
            }
            else
            {
                long selectionTime = DateTime.UtcNow.Second - charSelectTime;
                Debug.Log(selectionTime + " seconds for char " + 1);
                if (selectionTime > 3)
                {
                    if (correctWord.ToCharArray()[0].Equals(shuffledWord.ToCharArray()[0]))
                    {
                        wordGenerator.updateCharacter(0, shuffledWord[0]);
                    } else
                    {
                        Debug.Log("Incorrect.");
                    }
                }
            }
            
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 2800, 200, 800, 800))
        {
            Debug.Log("Second box is being selected ");
            if (!character.Equals('2'))
            {
                charSelectTime = DateTime.UtcNow.Second;
                character = '2';
            }
            else
            {
                long selectionTime = DateTime.UtcNow.Second - charSelectTime;
                Debug.Log(selectionTime + " seconds for char " + 2);
                if (selectionTime > 3)
                {
                    Debug.Log("Character 2 is selected " + shuffledWord);
                    if (correctWord.ToCharArray()[1].Equals(shuffledWord.ToCharArray()[1]))
                    {
                        wordGenerator.updateCharacter(1, shuffledWord[1]);
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                    }
                }
            }
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 2000, 200, 800, 800))
        {
            Debug.Log("Third box is being selected");
            if (!character.Equals('3'))
            {
                charSelectTime = DateTime.UtcNow.Second;
                character = '3';
            }
            else
            {
                long selectionTime = DateTime.UtcNow.Second - charSelectTime;
                Debug.Log(selectionTime + " seconds for char " + 3);
                if (selectionTime > 3)
                {
                    Debug.Log("Character 3 is selected " + shuffledWord[2]);
                    if (correctWord.ToCharArray()[2].Equals(shuffledWord.ToCharArray()[2]))
                    {
                        wordGenerator.updateCharacter(2, shuffledWord[2]);
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                    }
                }
            }
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 900, 0, 800, 800))
        {
            Debug.Log("Fourth box is being selected");
            if (!character.Equals('4'))
            {
                charSelectTime = DateTime.UtcNow.Second;
                character = '4';
            }
            else
            {
                long selectionTime = DateTime.UtcNow.Second - charSelectTime;
                Debug.Log(selectionTime + " seconds for char " + 4);
                if (selectionTime > 3)
                {
                    Debug.Log("Character 4 is selected " + shuffledWord[3]);
                    if (correctWord.ToCharArray()[3].Equals(shuffledWord.ToCharArray()[3]))
                    {
                        wordGenerator.updateCharacter(3, shuffledWord[3]);
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                    }
                }
            }
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 1800, 0, 800, 800))
        {
            Debug.Log("Fifth box is being selected");
            if (!character.Equals('5'))
            {
                charSelectTime = DateTime.UtcNow.Second;
                character = '5';
            }
            else
            {
                long selectionTime = DateTime.UtcNow.Second - charSelectTime;
                Debug.Log(selectionTime + " seconds for char " + 5);
                if (selectionTime > 3)
                {
                    Debug.Log("Character 5 is selected " + shuffledWord[4]);
                    if (correctWord.ToCharArray()[4].Equals(shuffledWord.ToCharArray()[4]))
                    {
                        wordGenerator.updateCharacter(4, shuffledWord[4]);
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                    }
                }
            }
        } else
        {
            character = 'X';
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
