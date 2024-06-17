using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] teamsColor;
    public string[] teamNames;
    public Color[] collectingColor; // Array of colors for each mesh
    private MeshRenderer[] meshRenderers;
    private int nextColorIndex = 0; // Index of the next color to use
    private static List<List<GameObject>> teams = new List<List<GameObject>>();
    int virusCounter = 0;

    private static GameSimulator gameSimulatorInstance; // Instanz der GameSimulator-Klasse

    void Start()
    {
        // Get all MeshRenderers of the circleObject's children
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
    public void InitializeTeams()
    {
        // Erstelle eine Instanz von TeamDivider
        OnCollisionPlayerCounter teamDivider = new OnCollisionPlayerCounter();

        // Rufe die Methode DividePlayersIntoTeams auf und erhalte die Teams
        teams = teamDivider.DividePlayersIntoTeams();
        for(int i = 0; i < teams.Count;i++)
        {
            foreach (GameObject player in teams[i])
            {
                MeshRenderer[] currentMeshRenderer = player.GetComponentsInChildren<MeshRenderer>();
                currentMeshRenderer[1].material.color = teamsColor[i];
            }
        }

    }
    private void Update()
    {
        if (StateManager.Instance.GetCurrentIndex() == 8)
        {
            OnCollisionPlayerCounter playerSpace = GameObject.FindObjectOfType<OnCollisionPlayerCounter>();
            playerSpace.enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object name starts with "virus"
        if (other.gameObject.name.StartsWith("virus", System.StringComparison.OrdinalIgnoreCase))
        {
            if (virusCounter < 4)
            {
                // Change the color of the next mesh
                this.meshRenderers[nextColorIndex + 2].material.color = collectingColor[nextColorIndex];

                // Move to the next color index (loop back to 0 if reached the end)
                nextColorIndex = (nextColorIndex + 1) % meshRenderers.Length;

                virusCounter++;

                Destroy(other.gameObject);
            }
        }

        for(int i = 0; i < teamNames.Length;i++)
        {
            if(this.meshRenderers[1].material.color == teamsColor[i] && virusCounter == 4)
            {
                if (other.gameObject.name.Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase))
                {
                    
                    PlayerPrefs.SetInt("virusCounter", virusCounter);
                    PlayerPrefs.SetString("team", teamNames[i]);
                    gameSimulatorInstance = GameObject.FindObjectOfType<GameSimulator>();
                    // Aufrufen der Methode ExecuteFunctionAfterRandomTime in der GameSimulator-Klasse
                    if (gameSimulatorInstance != null)
                    {
                        gameSimulatorInstance.ExecuteFunctionAfterRandomTime();
                    }
                    else
                    {
                        Debug.LogError("GameSimulator instance not found.",gameSimulatorInstance);
                    }

                    virusCounter = 0;
                    for (int x = 2; x < meshRenderers.Length; x++)
                    {
                        UnityEngine.Debug.Log("Resetting colors");
                        meshRenderers[x].material.color = Color.white;
                    }
                }
                nextColorIndex = 0;
                break;
            }
        }
    }
}
