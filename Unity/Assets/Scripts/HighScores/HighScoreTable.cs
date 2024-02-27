using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private string COLOR_GREEN = "00FF01"; //Color.HSVToRGB(1, 255, 0);
    private string COLOR_ORANGE = "FFBB00"; //Color.HSVToRGB(255, 187, 0);
    private string COLOR_PINK = "FF0089"; //Color.HSVToRGB(255, 0, 137);
    private string COLOR_BLUE = "0086FF"; //Color.HSVToRGB(0, 133, 255);

    private Transform entryContainer;
    private Transform entryTemplate;
    private Text entryContinueText;

    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");        
        entryTemplate.gameObject.SetActive(false);

        entryContinueText = entryContainer.Find("ContinueTeamText").Find("Text").GetComponent<Text>();
        entryContinueText.text = "";
        entryContinueText.gameObject.SetActive(false);

        InitializeHighScoreList();
        highScoreEntryList.Sort(new HighScoreComparer());

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry entry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(entry, entryContainer, highScoreEntryTransformList);
        }

        StartCoroutine(WaitAndClearContainer());
    }

    private IEnumerator WaitAndClearContainer()
    {
        yield return new WaitForSeconds(5f); 

        ClearHighScoreEntries(highScoreEntryTransformList.GetRange(1, highScoreEntryTransformList.Count - 2));
        highScoreEntryList.RemoveRange(1, highScoreEntryList.Count - 2);

        UpdateHighScoreEntries();
    }

    private void UpdateHighScoreEntries()
    {
        ClearHighScoreEntries(highScoreEntryTransformList);
        CreateHighScoreEntryTransform(highScoreEntryList[0], entryContainer, highScoreEntryTransformList);

        StartCoroutine(StartContinueText());
    }

    private IEnumerator StartContinueText()
    {
        yield return new WaitForSeconds(2f);

        entryContinueText.gameObject.SetActive(true);
        string continueText = "Congrats to team " + highScoreEntryList[0].name + "!\n Your team has now the honor to continue the game by encrypting the virus container. Good luck! ";
        TextWriter.AddWriterStatic(entryContinueText, continueText, .15f, false);
    }

    private void InitializeHighScoreList()
    {
        highScoreEntryList = new List<HighScoreEntry>();

        //wenn man die vorige scene nicht abgespielt hat
        if(PlayerPrefs.GetInt("teams_count") == 0)
        {
            highScoreEntryList = new List<HighScoreEntry>()
            {
                new HighScoreEntry(23234, "ORANGE"),
                new HighScoreEntry(342, "GREEN"),
                new HighScoreEntry(8342, "BLUE"),
                new HighScoreEntry(5623, "PINK"),
            };
        }

        int teamCount = PlayerPrefs.GetInt("teams_count");
        for (int i = 0; i < teamCount; i++) {

            int score = PlayerPrefs.GetInt("team_" + i) * 3;
            string name = PlayerPrefs.GetString("team_" + i + "_name");

            HighScoreEntry newEntry = new HighScoreEntry(score, name);
            highScoreEntryList.Add(newEntry);
        }
    }

    private void ClearHighScoreEntries(List<Transform> transformList)
    {
        foreach (Transform entryTransform in transformList)
        {
            Destroy(entryTransform.gameObject);
        }
        transformList.Clear();
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 280f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
            default: rankString = rank + "TH"; break;
        }

        entryTransform.Find("RankText").GetComponent<Text>().text = rankString;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = highscoreEntry.score.ToString();
        entryTransform.Find("TeamText").GetComponent<Text>().text = highscoreEntry.name;
        entryTransform.Find("Background").GetComponent<Image>().color = SetRightColor(highscoreEntry.name);

        switch(rank)
        {
            default: entryTransform.Find("Trophy").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("Trophy").GetComponent<Image>().color = HexToColor("D4AF37");
                break;
            case 2:
                entryTransform.Find("Trophy").GetComponent<Image>().color = HexToColor("C0C0C0");
                break;
            case 3:
                entryTransform.Find("Trophy").GetComponent<Image>().color = HexToColor("CD7F32");
                break;
        }

        transformList.Add(entryTransform);
    }

    private Color SetRightColor(string color)
    {
        Color rightColor = Color.white;
        switch (color.ToLower())
        {
            case "orange": rightColor = HexToColor(COLOR_ORANGE); break;
            case "blue": rightColor = HexToColor(COLOR_BLUE);  break;
            case "green": rightColor = HexToColor(COLOR_GREEN); break;
            case "pink": rightColor = HexToColor(COLOR_PINK); break;
        }
        return rightColor;
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    private class HighScoreEntry 
    {
        public int score;
        public string name;

        public HighScoreEntry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }

    private class HighScoreComparer : IComparer<HighScoreEntry>
    {
        public int Compare(HighScoreEntry a, HighScoreEntry b)
        {
            return a.score.CompareTo(b.score) * -1;
        }
    }
}
