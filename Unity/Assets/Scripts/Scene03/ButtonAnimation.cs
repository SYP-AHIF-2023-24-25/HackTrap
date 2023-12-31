﻿using System.Collections;
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
        btn.onClick.AddListener(delegate { Animation(); });
    }
    public void ChangeImage()
    {
        btn.GetComponent<Image>().sprite = sprite;
        btn.GetComponent<Image>().color = Color.green;
    }
    private void Animation()
    {
        GetComponent<Animator>().Play("ButtonAnimation");
    }
}
