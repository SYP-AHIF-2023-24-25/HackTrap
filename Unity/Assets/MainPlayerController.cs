﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private string[] teamNames;
    [SerializeField] private Color[] collectingColor;
    [SerializeField] private AudioClip clickSoundSlurp; // Der Soundclip für das Setzen eines Symbols
    private AudioSource audioSourceSlurp; // AudioSource für den Sound
    [SerializeField] private AudioClip clickSoundDump; // Der Soundclip für das Setzen eines Symbols
    private AudioSource audioSourceDump; // AudioSource für den Sound
    public MeshRenderer[] meshRenderers;
    private int nextColorIndex = 0;
    private int virusCounter = 0;

    private PlayerCounterController playerCounterController;
    private bool allWinnerPLayerReady = false;

    void Start()
    {
        audioSourceSlurp = gameObject.AddComponent<AudioSource>();
        audioSourceSlurp.clip = clickSoundSlurp;
        audioSourceSlurp.playOnAwake = false;
        audioSourceDump = gameObject.AddComponent<AudioSource>();
        audioSourceDump.clip = clickSoundDump;
        audioSourceDump.playOnAwake = false;
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        playerCounterController = FindObjectOfType<PlayerCounterController>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("gameOver") == 1 && StateManager.Instance.GetCurrentIndex() == 11 && allWinnerPLayerReady == false)
        {
            string winner = TeamVirusCounter.Instance.IsWinner();
            winner = winner == "Draw" ? "TeamBlue" : winner;


            var players = playerCounterController.GetAllPlayers();
            ResetColors();

            foreach (var player in players)
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
            audioSourceSlurp.Play();
        }

        Debug.Log("Collider tag name: " + other.gameObject.tag.ToString());
        if (other.CompareTag("Container1") || other.CompareTag("Container2"))
        {
            Debug.Log("Touched a team container");
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
            
            Debug.Log($"MeshRenderer index {meshRenderers.Length}");
            audioSourceDump.Play();
            Player p = GetComponent<Player>();


            Debug.Log(p.team.ToString() + " Vire wurde eingefangen (" + virusCounter + ")");
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Virus"))
            {
                if(obj.transform.localPosition == other.transform.localPosition)
                {
                    Destroy(obj);
                }
            }
        }
        //Debug.Log("viruses:" + virusCounter);
    }

    private void HandleTeamCollision(Collider other)
    {
        for (int i = 0; i < teamNames.Length; i++)
        {
            var player = this.gameObject.GetComponent<Player>();
            //Debug.Log(player.team);
            //Debug.Log(player.team.ToString());
            Debug.Log(teamNames[i]);

            if (other.gameObject.name.ToString().Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                ("Team" + player.team.ToString()).Equals(teamNames[i], System.StringComparison.OrdinalIgnoreCase) &&
                (virusCounter > 0 && virusCounter <= 4))
            {

                string containerName = other.gameObject.name;
                string playerName = "Team" + player.team.ToString();

                containerName = containerName.ToLower();
                playerName = playerName.ToLower();

                Debug.Log(playerName + " == " + containerName);

    
                Debug.Log($"{virusCounter} Viren wurden abgeladen");
                TeamVirusCounter.Instance.UpdateTeamCount(teamNames[i], virusCounter);
                //float progress = LoaderManager.Instance.GetCurrentLoaderProgress(i) + (0.5f * (virusCounter / 4.0f));
                //LoaderManager.Instance.UpdateLoaderProgress(i, progress, 2f);

                ResetColors();
            }
        }
    }

    public void ResetColors()
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
