using UnityEngine;
using System.Collections.Generic;

public class NewLoaderManager : MonoBehaviour
{
    public List<TextLoader> loaders = new List<TextLoader>(); // List of all loaders

    private float progress1 = 0.0f;
    private float progress2 = 0.0f;
    private float progress3 = 0.0f;
    private float progress4 = 0.0f;

    void Start()
    {
        // Load initial values from PlayerPrefs
        for (int i = 0; i < loaders.Count; i++)
        {
            float progress = PlayerPrefs.GetFloat($"LoaderProgress_{i}", 0f);
            loaders[i].SetProgress(progress);
        }
    }

    public void UpdateLoaderProgress(int index, float progress)
    {
        if (index < 0 || index >= loaders.Count) return;

        PlayerPrefs.SetFloat($"LoaderProgress_{index}", progress);
        loaders[index].SetProgress(progress);
    }

    public void Update()
    {
        if (PlayerPrefs.GetFloat("0") != progress1)
        {
            float progress = PlayerPrefs.GetFloat("0");
            PlayerPrefs.SetFloat($"LoaderProgress_0", progress);
            loaders[0].SetProgress(progress);
        }

        if (PlayerPrefs.GetFloat("1") != progress2)
        {
            float progress = PlayerPrefs.GetFloat("1");
            PlayerPrefs.SetFloat($"LoaderProgress_1", progress);
            loaders[1].SetProgress(progress);
        }

        if (PlayerPrefs.GetFloat("2") != progress3)
        {
            float progress = PlayerPrefs.GetFloat("2");
            PlayerPrefs.SetFloat($"LoaderProgress_2", progress);
            loaders[2].SetProgress(progress);
        }

        if (PlayerPrefs.GetFloat("3") != progress4)
        {
            float progress = PlayerPrefs.GetFloat("3");
            PlayerPrefs.SetFloat($"LoaderProgress_3", progress);
            loaders[3].SetProgress(progress);
        }
    }

    public void RegisterLoader(TextLoader loader)
    {
        if (!loaders.Contains(loader))
        {
            loaders.Add(loader);
        }
    }
}
