using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlayerController : MonoBehaviour
{
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
        if (PlayerPrefs.GetInt("gameOver") == 1 && StateManager.Instance.GetCurrentIndex() == 7)
        {
            string[] winners = LoaderManager.Instance.IsWinner();
            ResetColors();

            if (!new List<string>(winners).Contains(this.gameObject.tag))
            {
                this.gameObject.SetActive(false);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Virus"))
        {
            //Debug.Log("Touched virus");
            HandleVirusCollision(other);
        }
        else if (other.gameObject.tag.Contains("Container"))
        {
            Debug.Log("Touched container");
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
        //Debug.Log("viruses:" + virusCounter);
    }

    private void HandleTeamCollision(Collider other)
    {
        for (int i = 0; i < teamNames.Length; i++)
        {
            var player = this.gameObject.GetComponent<Player>();
            Debug.Log(player.team);
            Debug.Log(player.team.ToString());
            Debug.Log(teamNames[i]);

            if (other.gameObject.name.Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                ("Team" + player.team.ToString()).Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                (virusCounter > 0 && virusCounter <= 4))
            {
                float progress = LoaderManager.Instance.GetCurrentLoaderProgress(i) + (0.5f * (virusCounter / 4.0f));
                LoaderManager.Instance.UpdateLoaderProgress(i, progress, 2f);

                Debug.Log("viruses dispensed");

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
