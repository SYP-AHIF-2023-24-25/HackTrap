using DeepSpace.LaserTracking;
using System;
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
                StateManager.Instance.SwitchToNextScenePrefab();
            }
            isCorrect = true;
        }
        else
        {
            invalidSelectionAudio.Play();
            Debug.Log("Wrong character " + c + " at index " + shuffledIndex);
        }

        if (isCorrect)
        {
            validSelectionAudio.Play();
            switch (shuffledIndex)
            {
                case 0:
                    container1.SetActive(false);
                    break;
                case 1:
                    container2.SetActive(false);
                    break;
                case 2:
                    container3.SetActive(false);
                    break;
                case 3:
                    container4.SetActive(false);
                    break;
                case 4:
                    container5.SetActive(false);
                    break;
            }
        }
        else
        {
            switch (shuffledIndex)
            {
                case 0:
                    text1.GetComponent<Text>().color = Color.red;
                    colorChangeTimeContainer1 = DateTime.UtcNow.Second;
                    break;
                case 1:
                    text2.GetComponent<Text>().color = Color.red;
                    colorChangeTimeContainer2 = DateTime.UtcNow.Second;
                    break;
                case 2:
                    text3.GetComponent<Text>().color = Color.red;
                    colorChangeTimeContainer3 = DateTime.UtcNow.Second;
                    break;
                case 3:
                    text4.GetComponent<Text>().color = Color.red;
                    colorChangeTimeContainer4 = DateTime.UtcNow.Second;
                    break;
                case 4:
                    text5.GetComponent<Text>().color = Color.red;
                    colorChangeTimeContainer5 = DateTime.UtcNow.Second;
                    break;
            }
        }

        return isCorrect;
    }

    public void OnCollisionWithContainer1()
    {
        if (!character1Selected)
        {
            character1Selected = selectCharacter(shuffledWord[0], 0);
        }
    }

    public void OnCollisionWithContainer2()
    {
        if (!character2Selected)
        {
            character2Selected = selectCharacter(shuffledWord[1], 1);
        }
    }

    public void OnCollisionWithContainer3()
    {
        if (!character3Selected)
        {
            character3Selected = selectCharacter(shuffledWord[2], 2);
        }
    }

    public void OnCollisionWithContainer4()
    {
        if (!character4Selected)
        {
            character4Selected = selectCharacter(shuffledWord[3], 3);
        }
    }

    public void OnCollisionWithContainer5()
    {
        if (!character5Selected)
        {
            character5Selected = selectCharacter(shuffledWord[4], 4);
        }
    }

    void Start()
    {
        // Initialize containers and their state if needed
    }

    private void resetColors()
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
    }
}

