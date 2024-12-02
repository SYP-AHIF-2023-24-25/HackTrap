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
    private bool allWinnerPLayerReady = false;

    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        playerCounterController = FindObjectOfType<PlayerCounterController>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("gameOver") == 1 && StateManager.Instance.GetCurrentIndex() == 11 && allWinnerPLayerReady == false)
        {
            string winner = TeamVirusCounter.Instance.IsWinner();
            ResetColors();
            var players = playerCounterController.GetAllPlayers();
            foreach(var player in players)
            {
                if (winner.ToLower().Contains(player.team.ToString().ToLower()))
                {
                    player.tag = "Winner";
                }
            }
            allWinnerPLayerReady = true;
            //TODO: alle nicht winner inaktiv setzen:
            /*if (!new List<string>(winners).Contains(this.gameObject.tag))
            {
                this.gameObject.SetActive(false);
            }*/
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Virus"))
        {
            Debug.Log("Touched virus");
            HandleVirusCollision(other);
        }
        
        if (other.gameObject.tag.Contains("Container"))
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

            Debug.Log("Vire wurde eingefangen");
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
                Debug.Log($"{virusCounter} Viren wurden abgeladen");

                TeamVirusCounter.Instance.UpdateTeamCount(teamNames[i], virusCounter);
                //float progress = LoaderManager.Instance.GetCurrentLoaderProgress(i) + (0.5f * (virusCounter / 4.0f));
                //LoaderManager.Instance.UpdateLoaderProgress(i, progress, 2f);

                ResetColors();
            }
        }
    }

    private void ResetColors()
    {
        Debug.Log("Viruscounter wieder auf 0");
        virusCounter = 0;
        for (int i = 2; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = Color.white;
        }
        nextColorIndex = 0;
    }
}
