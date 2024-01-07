using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public int columns = 4; 

    void Start()
    {
        InstantiatePlayers();
    }

    void InstantiatePlayers()
    {
        int numberOfPlayers = 10; // userTracker.GetPlayerCount(); //--> später: number of players vom usertracking

        // X spacing ist in Unity immer 800
        // Y spacing ist in Unity immer 600

        float spacingX = 2.0f; 
        float spacingZ = 2.0f; 

        int rows = Mathf.CeilToInt((float)numberOfPlayers / columns);

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
}
