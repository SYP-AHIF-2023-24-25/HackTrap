using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private void Awake()
    {
        // Ensure that this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Ensure there is only one instance of the BackgroundMusicManager
        if (FindObjectsOfType<BackgroundMusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}