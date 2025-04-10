using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public AudioClip soundClip;  // Der Soundclip, der abgespielt werden soll
    private AudioSource audioSource;

    void Start()
    {
        // Füge eine AudioSource-Komponente zum GameObject hinzu, falls es noch keine hat
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.playOnAwake = false;  // Der Sound soll nicht direkt beim Start abgespielt werden
    }

    // Diese Methode wird aufgerufen, wenn ein Objekt den Trigger berührt
    void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob das andere Objekt der Spieler ist (je nach Tag oder Name des Spielerobjekts)
        if (other.CompareTag("DPlayer"))
        {
            audioSource.Play();  // Spiele den Sound ab
        }
    }
}
