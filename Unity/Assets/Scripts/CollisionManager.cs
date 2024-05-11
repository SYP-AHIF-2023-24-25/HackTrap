using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private static CollisionManager instance;

    public static CollisionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CollisionManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("CollisionManager");
                    instance = singleton.AddComponent<CollisionManager>();
                }
            }
            return instance;
        }
    }

    public GameObject player;
    private Renderer playerRenderer;
    private int collectedViruses = 0;
    private Color originalColor;
    private Color targetColor = Color.red; // Change this to the desired color

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get the renderer component of the sphere
        playerRenderer = player.GetComponent<Renderer>();
        // Store the original color of the sphere
        originalColor = playerRenderer.material.color;
    }

    public void CollectVirus(GameObject virus)
    {
        if (collectedViruses < 4)
        {
            virus.SetActive(false);
            collectedViruses++;
            Debug.Log(collectedViruses);
            float fillAmount = (float)collectedViruses / 4f; // Assuming you need to collect 4 viruses

            // Interpolate between original color and target color based on fill amount
            Color lerpedColor = Color.Lerp(originalColor, targetColor, fillAmount);
            // Update the sphere's material color
            playerRenderer.material.color = lerpedColor;
        }
    }
    public int ResetVirusCounter()
    {
        int gameCounter = collectedViruses;
        StartCoroutine(ResetColorAndCounter());
        return gameCounter;
    }

    private IEnumerator ResetColorAndCounter()
    {
        for (int i = 4; i >= 0; i--)
        {
            float fillAmount = (float)i / 4f; // Reverse the fill amount
            Color lerpedColor = Color.Lerp(originalColor, targetColor, fillAmount);
            playerRenderer.material.color = lerpedColor;
            collectedViruses--; // Decrement collectedViruses
            Debug.Log("Viruses left: " + collectedViruses);
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        collectedViruses = 0;
        playerRenderer.material.color = originalColor;
    }
}
