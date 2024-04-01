using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class OnSelection : MonoBehaviour
{

    public int sceneIndex;
    public GameObject tictactoe;
    public GameObject memory;
    public GameObject paperScissorsStone;

    public GameObject floorTictactoe;
    public GameObject floorMemory;
    public GameObject floorPaperScissorsStone;

    public Texture2D disabledSprite;

    // Animation duration
    public float animationDuration = 0.5f;

    // Reference to the RawImage components
    private RawImage memoryRawImage;
    private RawImage paperScissorsStoneRawImage;
    private RawImage floorMemoryRawImage;
    private RawImage floorPaperScissorsStoneRawImage;

    // Flag to prevent animation overlap
    private bool isAnimating = false;

    public AudioSource audioSource;

    void Start()
    {
        // Get references to RawImage components
        memoryRawImage = memory.GetComponent<RawImage>();
        paperScissorsStoneRawImage = paperScissorsStone.GetComponent<RawImage>();
        floorMemoryRawImage = floorMemory.GetComponent<RawImage>();
        floorPaperScissorsStoneRawImage = floorPaperScissorsStone.GetComponent<RawImage>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimating)
        {
            
            // Cast a ray from the camera to the position of the mouse pointer
            Vector3 clickPosition = Input.mousePosition;
            UnityEngine.Debug.Log(clickPosition.x);

            if (clickPosition.x > 130 && clickPosition.x < 290)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else if (clickPosition.x > 307 && clickPosition.x < 465)
            {
                // Start fade animation
                StartCoroutine(FadeAnimation(paperScissorsStoneRawImage));
                StartCoroutine(FadeAnimation(floorPaperScissorsStoneRawImage));
            }
            else if (clickPosition.x > 481 && clickPosition.x < 645)
            {
                // Start fade animation
                StartCoroutine(FadeAnimation(memoryRawImage));
                StartCoroutine(FadeAnimation(floorMemoryRawImage));
            }
        }
    }

    IEnumerator FadeAnimation(RawImage rawImage)
    {
        audioSource.Play();
        isAnimating = true;

        // Store initial aspect ratio
        float initialAspectRatio = (float)rawImage.texture.width / rawImage.texture.height;

        // Fade out
        float elapsedTime = 0f;
        Color startColor = rawImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            rawImage.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        // Set texture and reset color
        rawImage.texture = disabledSprite;
        rawImage.color = startColor;

        // Adjust aspect ratio
        //rawImage.rectTransform.sizeDelta = new Vector2(1500, 1500);

        isAnimating = false;
    }
}