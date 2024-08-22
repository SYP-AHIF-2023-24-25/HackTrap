using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private Color[] teamsColor;
    [SerializeField] private string[] teamNames;
    [SerializeField] private Color[] collectingColor;
    private MeshRenderer[] meshRenderers;
    private int nextColorIndex = 0;
    private int virusCounter = 0;

    private PlayerCounterController playerCounterController;
    private bool isState8Handled = false;

    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        playerCounterController = FindObjectOfType<PlayerCounterController>();
    }

    private void Update()
    {
        int currentState = StateManager.Instance.GetCurrentIndex();

        if (currentState == 7)
        {
            string[] winners = LoaderManager.Instance.IsWinner();

            if (winners.Length > 0)
            {
                ResetColors();

                if (!new List<string>(winners).Contains(this.gameObject.tag))
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Virus"))
        {
            HandleVirusCollision(other);
        }
        else if (other.gameObject.tag.Contains("Container"))
        {
            HandleTeamCollision(other);
        }
    }

    private void HandleVirusCollision(Collider other)
    {
        if (virusCounter < 4)
        {
            meshRenderers[nextColorIndex + 2].material.color = collectingColor[nextColorIndex];
            nextColorIndex = (nextColorIndex + 1) % (meshRenderers.Length - 2);
            virusCounter++;
            Destroy(other.gameObject);
        }
    }

    private void HandleTeamCollision(Collider other)
    {
        for (int i = 0; i < teamNames.Length; i++)
        {
            if (other.gameObject.name.Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                this.tag.Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                (virusCounter > 0 && virusCounter <= 4))
            {
                float progress = LoaderManager.Instance.GetCurrentLoaderProgress(i) + (0.1f * (virusCounter / 4.0f));
                LoaderManager.Instance.UpdateLoaderProgress(i, progress, 2f);
                ResetColors();
            }
        }
    }

    private void ResetColors()
    {
        virusCounter = 0;
        for (int i = 2; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = Color.white;
        }
        nextColorIndex = 0;
    }
}
