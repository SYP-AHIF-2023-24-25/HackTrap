using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public UserTracker userTracker;
    public GameObject playerPrefab;
    public int minColumns = 4;
    public int numberOfPlayers = 20; //irgendeine zahl

    private bool[] players;

    void Start()
    {
        //numberOfPlayers = userTracker.GetPlayerCount(); //--> später: number of players vom usertracking
        players = new bool[numberOfPlayers];
        InstantiatePlayers();
    }

    /// <summary>
    /// zeichnet die felder, um die spieler
    /// als player für teams zu inizialisieren
    /// </summary>
    void InstantiatePlayers()
    {
        // X spacing ist in Unity immer 800
        // Y spacing ist in Unity immer 600

        float spacingX = 2.0f; 
        float spacingZ = 2.0f;

        int maxColumns = Mathf.Max(minColumns, Mathf.CeilToInt(Mathf.Sqrt(numberOfPlayers))); // Spaltenanzahl berechnen, wenn z.B. mehr spieler als 4^2 sind, werden spalten mehr

        int columns = Mathf.Clamp(maxColumns, minColumns, int.MaxValue); 
        int rows = Mathf.CeilToInt((float)numberOfPlayers / columns); // Anzahl der Reihen berechnen


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int playerIndex = row * columns + col;

                if (playerIndex < numberOfPlayers)
                {
                    float xPos = col * spacingX;
                    float zPos = row * spacingZ;

                    Vector3 position = new Vector3(xPos, 0.5f, zPos);
                    Instantiate(playerPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {

    }

    /// <summary>
    /// überprüft, ob alle spieler in einem Feld sind
    /// </summary>
    bool AllFieldsOccupied()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i])
            {
                return false;
            }
        }
        return true;
    }
}
