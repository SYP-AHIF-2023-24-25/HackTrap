using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Sprite sprite;
    public Button btn;
    private void Start()
    {
        btn.onClick.AddListener(delegate { ChangeImage(); });
    }
    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }
    public void ChangeImage()
    {
        btn.GetComponent<Image>().sprite = sprite;
        btn.GetComponent<Image>().color = Color.green;
    }
}
