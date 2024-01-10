using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip firstThreeScenesMusic;
    public AudioClip sceneSixMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check the current scene and play the appropriate music
        PlayMusicBasedOnScene();
    }

    void PlayMusicBasedOnScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 0 && currentSceneIndex <= 2)
        {
            // Play music for the first three scenes
            audioSource.clip = firstThreeScenesMusic;
            audioSource.Play();
        }
        else if (currentSceneIndex >= 3 && currentSceneIndex <= 5)
        {
            // Stop music for scenes 4 and 5
            audioSource.Stop();
        }
        else if (currentSceneIndex == 6)
        {
            // Play different music for scene 6
            audioSource.clip = sceneSixMusic;
            audioSource.Play();
        }
    }
}