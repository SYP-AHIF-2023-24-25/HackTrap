using DeepSpace.LaserTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Context : MonoBehaviour
{

    int persons;
    long charSelectTime;
    char character;

    string correctWord;
    string shuffledWord;

    public WallUpdateScript wallUpdateScript;

    bool character1Selected;
    bool character2Selected;
    bool character3Selected;
    bool character4Selected;
    bool character5Selected;

    public GameObject container1;
    public GameObject container2;
    public GameObject container3;
    public GameObject container4;
    public GameObject container5;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;

    private long colorChangeTimeContainer1;
    private long colorChangeTimeContainer2;
    private long colorChangeTimeContainer3;
    private long colorChangeTimeContainer4;
    private long colorChangeTimeContainer5;

    int selectionIndex = 0;

    public AudioSource invalidSelectionAudio;
    public AudioSource validSelectionAudio;

    public int timeout = 0;




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



    private bool selectCharacter(char c, int shuffledIndex)
    {
        bool isCorrect = false;
        Debug.Log("Selecting " + selectionIndex + " from " + correctWord);
        Debug.Log("At Index " + selectionIndex + " character is " + correctWord.ToCharArray()[selectionIndex]);


        
        if (selectionIndex < 5 && correctWord.ToCharArray()[selectionIndex] == c)
        {
            wallUpdateScript.updateCharacter(selectionIndex, correctWord.ToCharArray()[selectionIndex]);
            Debug.Log("Selected " + c);
            selectionIndex++;
            if (selectionIndex == 5)
            {
                SceneManager.LoadScene(13);

            }

            isCorrect = true;
        } else
        {
            invalidSelectionAudio.Play();
            Debug.Log("Wrong character " + c + " at index " + shuffledIndex);
        }

  

        if (isCorrect)
        {
            validSelectionAudio.Play();
            if (shuffledIndex == 0)
            {
                container1.SetActive(false);
            }
            if (shuffledIndex == 1)
            {
                container2.SetActive(false);
            }
            if (shuffledIndex == 2)
            {
                container3.SetActive(false);
            }
            if (shuffledIndex == 3)
            {
                container4.SetActive(false);
            }
            if (shuffledIndex == 4)
            {
                container5.SetActive(false);
            }
        }

        if (!isCorrect)
        {
            
            if (shuffledIndex == 0)
            {
                text1.GetComponent<Text>().color = Color.red;
                colorChangeTimeContainer1 = DateTime.UtcNow.Second;
            }
            if (shuffledIndex == 1)
            {
                text2.GetComponent<Text>().color = Color.red;
                colorChangeTimeContainer2 = DateTime.UtcNow.Second;
            }
            if (shuffledIndex == 2)
            {
                text3.GetComponent<Text>().color = Color.red;
                colorChangeTimeContainer3 = DateTime.UtcNow.Second;
            }
            if (shuffledIndex == 3)
            {
                text4.GetComponent<Text>().color = Color.red;
                colorChangeTimeContainer4 = DateTime.UtcNow.Second;
            }
            if (shuffledIndex == 4)
            {
                text5.GetComponent<Text>().color = Color.red;
                colorChangeTimeContainer5 = DateTime.UtcNow.Second;
            }
        }

        return isCorrect;
    }


    public void receiveEvents(TrackRecord track)
    {
        //Debug.Log("Received track record X: " + track.currentPos.x + " Y: " + track.currentPos);

        if(IsInBox(track.currentPos.x, track.currentPos.y, -1800, 0, 800, 800) && !character1Selected)
        {
            selectCharacter(shuffledWord[0], 0);
            //Debug.Log("First box is being selected " + shuffledWord[0]);
            //if(!character.Equals('1'))
            //{
            //    charSelectTime = DateTime.UtcNow.Second;
            //    character = '1';
            //}
            //else
            //{
            //    long selectionTime = DateTime.UtcNow.Second - charSelectTime;
            //    Debug.Log(selectionTime + " seconds for char " + 1);
            //    if (selectionTime > 3)
            //    {
            //        if (selectCharacter(shuffledWord[0]))
            //        {
            //            character1Selected = true;

            //        } else
            //        {
            //            Debug.Log("Incorrect.");

            //        }
            //    }
            //}

        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, -900, 0, 800, 800) && !character2Selected)
        {
            selectCharacter(shuffledWord[1], 1);
            //Debug.Log("Second box is being selected ");
            //if (!character.Equals('2'))
            //{
            //    charSelectTime = DateTime.UtcNow.Second;
            //    character = '2';
            //}
            //else
            //{
            //    long selectionTime = DateTime.UtcNow.Second - charSelectTime;
            //    Debug.Log(selectionTime + " seconds for char " + 2);
            //    if (selectionTime > 3)
            //    {
            //        Debug.Log("Character 2 is selected " + shuffledWord);
            //        if (selectCharacter(shuffledWord[1]))
            //        {
            //            character2Selected = true;
            //        }
            //        else
            //        {
            //            Debug.Log("Incorrect.");
            //        }
            //    }
            //}
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 0, 0, 800, 800) && !character3Selected)
        {
            selectCharacter(shuffledWord[2], 2);
            //Debug.Log("Third box is being selected");
            //if (!character.Equals('3'))
            //{
            //    charSelectTime = DateTime.UtcNow.Second;
            //    character = '3';
            //}
            //else
            //{
            //    long selectionTime = DateTime.UtcNow.Second - charSelectTime;
            //    Debug.Log(selectionTime + " seconds for char " + 3);
            //    if (selectionTime > 3)
            //    {
            //        Debug.Log("Character 3 is selected " + shuffledWord[2]);
            //        if (selectCharacter(shuffledWord[2]))
            //        {
            //            character3Selected = true;
            //        }
            //        else
            //        {
            //            Debug.Log("Incorrect.");
            //        }
            //    }
            //}
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 900, 0, 800, 800) && !character4Selected)
        {
            selectCharacter(shuffledWord[3], 3);
            //Debug.Log("Fourth box is being selected");
            //if (!character.Equals('4'))
            //{
            //    charSelectTime = DateTime.UtcNow.Second;
            //    character = '4';
            //}
            //else
            //{
            //    long selectionTime = DateTime.UtcNow.Second - charSelectTime;
            //    Debug.Log(selectionTime + " seconds for char " + 4);
            //    if (selectionTime > 3)
            //    {
            //        Debug.Log("Character 4 is selected " + shuffledWord[3]);
            //        if (selectCharacter(shuffledWord[3]))
            //        {
            //            character4Selected = true;
            //        }
            //        else
            //        {
            //            Debug.Log("Incorrect.");
            //        }
            //    }
            //}
        }

        else if (IsInBox(track.currentPos.x, track.currentPos.y, 1800, 0, 800, 800) && !character5Selected)
        {
            Debug.Log("Selecting " + shuffledWord[4]);
            selectCharacter(shuffledWord[4], 4);
            //Debug.Log("Fifth box is being selected");
            //if (!character.Equals('5'))
            //{
            //    charSelectTime = DateTime.UtcNow.Second;
            //    character = '5';
            //}
            //else
            //{
            //    long selectionTime = DateTime.UtcNow.Second - charSelectTime;
            //    Debug.Log(selectionTime + " seconds for char " + 5);
            //    if (selectionTime > 3)
            //    {
            //        Debug.Log("Character 5 is selected " + shuffledWord[4]);
            //        if (selectCharacter(shuffledWord[4]))
            //        {
            //            character5Selected = true;
            //        }
            //        else
            //        {
            //            Debug.Log("Incorrect.");
            //        }
            //    }
            //}
        } else
        {
            character = 'X';
            charSelectTime = DateTime.UtcNow.Second;
        }
    }

    void Start()
    {

        
    }

    private float delayTimer = 0.1f;
    private bool updateAllowed = false;

    void resetColors()
    {
        long colorResetContainer1 = DateTime.UtcNow.Second - colorChangeTimeContainer1;
        long colorResetContainer2 = DateTime.UtcNow.Second - colorChangeTimeContainer2;
        long colorResetContainer3 = DateTime.UtcNow.Second - colorChangeTimeContainer3;
        long colorResetContainer4 = DateTime.UtcNow.Second - colorChangeTimeContainer4;
        long colorResetContainer5 = DateTime.UtcNow.Second - colorChangeTimeContainer5;
        
        if (colorResetContainer1 > 2 && text1.GetComponent<Text>().color == Color.red)
        {
            text1.GetComponent<Text>().color = Color.white;
        }

        if (colorResetContainer2 > 2 && text2.GetComponent<Text>().color == Color.red)
        {
            text2.GetComponent<Text>().color = Color.white;
        }

        if (colorResetContainer3 > 2 && text3.GetComponent<Text>().color == Color.red)
        {
            text3.GetComponent<Text>().color = Color.white;
        }

        if (colorResetContainer4 > 2 && text4.GetComponent<Text>().color == Color.red)
        {
            text4.GetComponent<Text>().color = Color.white;
        }

        if (colorResetContainer5 > 2 && text5.GetComponent<Text>().color == Color.red)
        {
            text5.GetComponent<Text>().color = Color.white;
        }
    }

    private void Update()
    {
        
        resetColors();

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the position of the mouse pointer
            Vector3 clickPosition = Input.mousePosition;

            Debug.Log("Clicked at: " + clickPosition.x);

            if(clickPosition.x > 120 && clickPosition.x < 200)
            {
                TrackRecord trackRecord = new TrackRecord();
                trackRecord.currentPos.x = -1799;
                trackRecord.currentPos.y = 1;

                receiveEvents(trackRecord);
            }
            else if (clickPosition.x > 225 && clickPosition.x < 300)
            {
                TrackRecord trackRecord = new TrackRecord();
                trackRecord.currentPos.x = -899;
                trackRecord.currentPos.y = 1;

                receiveEvents(trackRecord);
            }
            else if (clickPosition.x > 330 && clickPosition.x < 410)
            {
                TrackRecord trackRecord = new TrackRecord();
                trackRecord.currentPos.x = 1;
                trackRecord.currentPos.y = 1;

                receiveEvents(trackRecord);
            }
            else if (clickPosition.x > 430 && clickPosition.x < 510)
            {
                TrackRecord trackRecord = new TrackRecord();
                trackRecord.currentPos.x = 901;
                trackRecord.currentPos.y = 1;

                receiveEvents(trackRecord);
            }
            else if (clickPosition.x > 530 && clickPosition.x < 610)
            {
                TrackRecord trackRecord = new TrackRecord();
                trackRecord.currentPos.x = 1801;
                trackRecord.currentPos.y = 1;

                receiveEvents(trackRecord);
            }


        }

    }
}
