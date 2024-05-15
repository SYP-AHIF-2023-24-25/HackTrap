using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors; // Array of colors for each mesh
    private MeshRenderer[] meshRenderers;
    private int nextColorIndex = 0; // Index of the next color to use
    public string teamName;

    int virusCounter = 0;

    GameSimulator gameSimulatorInstance; // Instanz der GameSimulator-Klasse

    void Start()
    {
        // Get all MeshRenderers of the circleObject's children
        meshRenderers = GetComponentsInChildren<MeshRenderer>();

        // Ensure the number of colors matches the number of MeshRenderers
        if (colors.Length != meshRenderers.Length)
        {
            Debug.LogError("Number of colors does not match the number of MeshRenderers.");
            return;
        }

        // Instanz der GameSimulator-Klasse holen
        gameSimulatorInstance = GameObject.FindObjectOfType<GameSimulator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object name starts with "virus"
        if (other.gameObject.name.StartsWith("virus", System.StringComparison.OrdinalIgnoreCase))
        {
            if (virusCounter < 5)
            {
                // Change the color of the next mesh
                meshRenderers[nextColorIndex].material.color = colors[nextColorIndex];

                // Move to the next color index (loop back to 0 if reached the end)
                nextColorIndex = (nextColorIndex + 1) % meshRenderers.Length;

                virusCounter++;

                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.name.Equals(teamName, System.StringComparison.OrdinalIgnoreCase))
        {
            PlayerPrefs.SetInt("virusCounter", virusCounter);
            PlayerPrefs.SetString("team", teamName);

            // Aufrufen der Methode ExecuteFunctionAfterRandomTime in der GameSimulator-Klasse
            if (gameSimulatorInstance != null)
            {
                gameSimulatorInstance.ExecuteFunctionAfterRandomTime();
            }
            else
            {
                Debug.LogError("GameSimulator instance not found.");
            }

            virusCounter = 0;
            for (int i = 1; i < meshRenderers.Length; i++)
            {
                UnityEngine.Debug.Log("Resetting colors");
                meshRenderers[i].material.color = Color.white;
            }
        }
    }
}
