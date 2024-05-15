using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScaleImage : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private RectTransform rectTransform;
    bool hover;

    public float scaleSpeed = 5f;

    Outline outline;
    public Color normalOutlineColor = Color.white;

    public Color hoverOutlineColor = Color.blue;

    void Start()
    {
        /*
        outline = GetComponent<Outline>();
        outline.effectColor = normalOutlineColor;
        originalScale = transform.localScale;
        rectTransform = GetComponent<RectTransform>();

        */
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        targetScale = originalScale * 1.2f;
        outline.effectColor = hoverOutlineColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = true;
        targetScale = originalScale;
        outline.effectColor = normalOutlineColor;
    }

    void Update()
    {
        if(hover == true)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        }   
    }
}
