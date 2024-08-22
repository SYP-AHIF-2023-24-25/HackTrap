using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sceneAudioClips; // Array of audio clips to choose from

    [SerializeField]
    private float volume;

    private AudioSource audioSource;
    private Coroutine fadeOutCoroutine;

    [SerializeField] private bool loop = true;

    private void Awake()
    {
        // Ensure there is an AudioSource component attached to the prefab
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        if (volume == 0.0f)
        {
            volume = 1.0f;
        }
        audioSource.loop = loop; // Loop the audio clip
    }

    private void OnEnable()
    {
        PlayRandomAudio();
    }

    // Method to handle switching prefabs with fade-out effect
    public void SwitchAudio(float fadeDuration)
    {
        if (fadeOutCoroutine != null)
        {
            StopCoroutine(fadeOutCoroutine);
        }
        //fadeOutCoroutine = StartCoroutine(FadeOutAndSwitch(fadeDuration));
    }

    // Coroutine to fade out the current audio and then switch to a new one
    private IEnumerator FadeOutAndSwitch(float fadeDuration)
    {
        float startVolume = audioSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Increment elapsedTime by the time passed since last frame
            elapsedTime += Time.deltaTime;

            // Calculate the new volume
            float newVolume = Mathf.Lerp(startVolume, 0, elapsedTime / fadeDuration);
            audioSource.volume = newVolume;

            // Wait until the next frame
            yield return null;
        }

        // Ensure volume is set to 0 at the end
        audioSource.volume = 0;
        audioSource.Stop();
    }

    // Method to play a random audio clip from the array
    private void PlayRandomAudio()
    {
        if (sceneAudioClips.Length > 0)
        {
            audioSource.clip = sceneAudioClips[Random.Range(0, sceneAudioClips.Length)];
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
