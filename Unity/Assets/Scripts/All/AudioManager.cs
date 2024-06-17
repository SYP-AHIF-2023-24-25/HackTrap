using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sceneAudioClips; // Array of audio clips to choose from

    private AudioSource audioSource;
    private Coroutine fadeOutCoroutine;

    [SerializeField] private bool loop = true;

    private void Awake()
    {
        // Ensure there is an AudioSource component attached to the prefab
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = loop; // Loop the audio clip
    }

    private void OnEnable()
    {
        // Pick a random audio clip from the array
        if (sceneAudioClips.Length > 0)
        {
            audioSource.clip = sceneAudioClips[Random.Range(0, sceneAudioClips.Length)];
            audioSource.Play();
        }
    }

    private void OnDisable()
    {
        // Stop the audio with a fade-out effect when the prefab is disabled
        if (fadeOutCoroutine != null)
        {
            StopCoroutine(fadeOutCoroutine);
        }
        //fadeOutCoroutine = StartCoroutine(FadeOutAndStop(1f)); // Adjust fade duration as needed
    }

    private IEnumerator FadeOutAndStop(float fadeDuration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume for next use
    }
}
