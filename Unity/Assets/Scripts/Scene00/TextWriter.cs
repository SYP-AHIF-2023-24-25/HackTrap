﻿
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextWriter: MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriterStatic(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters));
    }

    private void Update()
    {
        Debug.Log(textWriterSingleList.Count);
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
}

//eine einzige Textwriter instance
public class TextWriterSingle
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private bool invisibleCharacters;

    public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    public bool Update()
    {
        timer -= Time.deltaTime;
        while (timer <= 0f)
        {
            //Nächsten Buchstaben hinschreiben
            timer += timePerCharacter;
            characterIndex++;

            if (textToWrite[characterIndex - 1] == '\n')
            {
                // Wenn der aktuelle Buchstabe ein Zeilenumbruch ist, lösche den Text bis jetzt
                uiText.text = "";
                textToWrite = textToWrite.Substring(characterIndex); // Den bereits angezeigten Text aus textToWrite löschen
                characterIndex = 0;
            }
            else
            {
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += textToWrite.Substring(0, characterIndex);
                }
                uiText.text = text;
            }

            if (characterIndex >= textToWrite.Length)
            {
                //der ganze Text wurde angezeigt
                uiText.text = "";

                //Scene Switch
                Thread.Sleep(3000);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                return true;
            }
        }
        return false;
    }
}