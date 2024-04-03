using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject player;
    private Renderer playerRenderer;
    private int collectedViruses = 0;
    private Color originalColor;
    private Color targetColor = Color.green; // Change this to the desired color

    private void Start()
    {
        // Get the renderer component of the sphere
        playerRenderer = player.GetComponent<Renderer>();
        // Store the original color of the sphere
        originalColor = playerRenderer.material.color;
    }

    public void CollectVirus()
    {
        if(collectedViruses <= 4)
        {
            collectedViruses++;
            float fillAmount = (float)collectedViruses / 4f; // Assuming you need to collect 4 viruses

            // Interpolate between original color and target color based on fill amount
            Color lerpedColor = Color.Lerp(originalColor, targetColor, fillAmount);
            // Update the sphere's material color
            playerRenderer.material.color = lerpedColor;
        }
        else
        {
            PlayerPrefs.SetInt("virusCubeCounter", collectedViruses);
        }
    }
}
