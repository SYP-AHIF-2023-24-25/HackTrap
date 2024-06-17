using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance; // Singleton instance

    [SerializeField] private GameObject[] scenePrefabs; // Array of scene prefabs
    [SerializeField] private float sceneSwitchDelay = 3f; // Default delay before switching scenes

    [SerializeField] private int initialScene = 0;
    //[SerializeField] private Animator animator;


    private GameObject currentScenePrefab;
    private int currentSceneIndex = 0; // first scene is active

    private void Awake()
    {
        // Enforce singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Disable all scene prefabs when the SceneManager starts
        foreach (GameObject prefab in scenePrefabs)
        {
            prefab.SetActive(false);
        }

        //Enable first scene prefab only
        scenePrefabs[initialScene].SetActive(true);
        currentScenePrefab = scenePrefabs[initialScene];
        currentSceneIndex = initialScene;
    }

    // Switch to a new scene prefab after a delay
    public void SwitchSceneAfterDelay(int sceneIndex, float delay = -1)
    {
        StartCoroutine(SwitchSceneCoroutine(sceneIndex, delay));
    }

    // Coroutine for switching scene after a delay
    private IEnumerator SwitchSceneCoroutine(int sceneIndex, float delay)
    {
        if (delay < 0)
            delay = sceneSwitchDelay;

        yield return new WaitForSeconds(delay);

        SwitchToScenePrefab(sceneIndex);
    }

    // Switch to a new scene prefab immediately
    public void SwitchToScenePrefab(int sceneIndex)
    {
        if (currentScenePrefab != null)
        {
            currentScenePrefab.SetActive(false);
        }

        currentScenePrefab = scenePrefabs[sceneIndex];
        currentScenePrefab.SetActive(true);
        currentSceneIndex = sceneIndex;
    }

    // Switch to the next scene prefab
    public void SwitchToNextScenePrefab()
    {
        currentSceneIndex = (currentSceneIndex + 1) % scenePrefabs.Length;
        SwitchToScenePrefab(currentSceneIndex);
        Debug.Log("YourMethod is being called!");
        Debug.Log(System.Environment.StackTrace);
    }

    public IEnumerator SwitchSceneAfterAnimation(Animator animator)
    {
        Debug.Log("Switch scene");
        // Wait for the end animation to complete
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }

        // Optionally switch the scene after the animation completes
        SwitchSceneAfterDelay(currentSceneIndex + 1, 2f);
    }

    public int GetCurrentIndex()
    {
        return currentSceneIndex;
    }
}
