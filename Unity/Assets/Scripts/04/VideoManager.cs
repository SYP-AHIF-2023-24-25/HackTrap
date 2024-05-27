using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [System.Serializable]
    public class VideoContainer
    {
        public GameObject container;
        public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
        public float startDelay; // Time in seconds before this container is enabled
    }

    public VideoContainer[] videoContainers; // Array of containers and their start delays
    public float videoDuration; // Duration after which all videos should end

    private float elapsedTime = 0f;
    private bool videosStarted = false;

    void Update()
    {
        if (!videosStarted)
        {
            elapsedTime += Time.deltaTime;

            foreach (var videoContainer in videoContainers)
            {
                if (elapsedTime >= videoContainer.startDelay)
                {
                    videoContainer.container.SetActive(true);

                    if (videoContainer.videoPlayer != null)
                    {
                        videoContainer.videoPlayer.Prepare();
                        videoContainer.videoPlayer.Play();
                    }
                }
            }

            if (elapsedTime >= videoDuration)
            {
                videosStarted = true;
            }
        }
    }

    void Start()
    {
        foreach (var videoContainer in videoContainers)
        {
            videoContainer.container.SetActive(false);
        }
    }
}
