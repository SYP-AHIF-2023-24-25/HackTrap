using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnCollisionPlayerCounter : MonoBehaviour
{
    // Variable zur Speicherung der Anzahl der Spieler im Bereich
    public Text playerCountTextField;
    private int playerCount = 0;

    // Methode, die aufgerufen wird, wenn ein Spieler den Collider betritt
    void OnTriggerEnter(Collider other)
    {
        playerCount++;

        if (playerCount == 4)
        {
            StateManager.Instance.SwitchToNextScenePrefab();
        }
        Debug.Log("Spieler betreten den Bereich. Anzahl: " + playerCount);
        UpdatePlayerCountText();
    }
    void UpdatePlayerCountText()
    {
        // Aktualisiere den Text, um die aktuelle Spieleranzahl anzuzeigen
        playerCountTextField.text = "PLayers on field: " + playerCount;
    }
}
