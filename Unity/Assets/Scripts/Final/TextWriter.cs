using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
public class TextWriter : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private string textToWrite;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, text));
    }

    private void Update()
    {
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

*/

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    public string textToWrite;
    private float timePerCharacter = 1f;
    private float timer = 1f;
    private int characterIndex = 10;
    private bool invisibleCharacters = false;


    public bool Update()
    {
        timer -= Time.deltaTime;
        while (timer <= 0f)
        {
            timer += timePerCharacter;
            characterIndex++;

            if (textToWrite[characterIndex - 1] == '\n')
            {
                uiText.text = "";
                textToWrite = textToWrite.Substring(characterIndex);
                characterIndex = 0;
            }
            else
            {
                string displayText = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    displayText += new string(' ', characterIndex - 1);
                }
                uiText.text = displayText;
            }

            if (characterIndex >= textToWrite.Length)
            {
                uiText.text = "";
                // You might want to trigger Scene switch outside of this class.
                return true;
            }
        }
        return false;
    }
}
