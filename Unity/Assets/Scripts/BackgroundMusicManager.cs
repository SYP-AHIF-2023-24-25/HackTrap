using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusicManager : MonoBehaviour
{

    public static BackgroundMusicManager instance;
    public AudioClip music7;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            int index = SceneManager.GetActiveScene().buildIndex;

            if (index == 7)
            {
                instance.GetComponent<AudioSource>().clip = music7;
            }

        }
    }

    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 7)
        {
            instance.GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index > 3 && index <= 6)
        {
            instance.GetComponent<AudioSource>().Pause();
        }
    }

}