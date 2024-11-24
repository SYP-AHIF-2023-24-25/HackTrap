using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledPlayerSounds : MonoBehaviour
{
    public GameController gameController; // Referenz auf den GameController
    public AudioSource soundDisabledPlayer; // Audioquelle für den Sound

    /*private void OnTriggerEnter(Collider other)
    {
        // Spieler ermitteln (anpassen je nach Erkennungsmethode)
        Player currentPlayer = GetCurrentPlayer();

        if (currentPlayer != null && currentPlayer.isDisabled)
        {
            PlayDisabledPlayerSound();
        }
    }

    private Player GetCurrentPlayer()
    {
        if (gameController != null)
        {
            foreach (var player in gameController.disabledPlayers)
            {
                Debug.Log("Spieler: " + player.name);
            }
        }

        Debug.LogWarning("Kein Spieler gefunden oder GameController ist null!");
        return null;
    }

    private void PlayDisabledPlayerSound()
    {
        if (soundDisabledPlayer != null)
        {
            soundDisabledPlayer.Play(); // Spiele den Sound ab
            Debug.Log("Sound für disabled Spieler abgespielt!");
        }
        else
        {
            Debug.LogWarning("Keine AudioSource zugewiesen!");
        }
    }*/
}
