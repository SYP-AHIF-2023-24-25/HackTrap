using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupOne : MonoBehaviour
{
    public int time;
    public int positionX;
    public int positionY;
    private Canvas canvas;

    private float sceneRuntime;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        UnityEngine.Debug.Log("Runtime debug: Start");

        sceneRuntime = Time.timeSinceLevelLoad;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        Invoke("showCanvas", time);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        UnityEngine.Debug.Log("Runtime debug: Change of Scene");
        sceneRuntime = Time.time;
    }

    void showCanvas()
    {

        canvas.enabled = true;
        GetComponent<Canvas>().GetComponent<RectTransform>().anchoredPosition = new Vector2(positionX, positionY);
    }

    // Update is called once per frame
    void Update()
    {
        sceneRuntime = Time.timeSinceLevelLoad - sceneRuntime;

        UnityEngine.Debug.Log("Runtime debug: " + sceneRuntime);

        if(sceneRuntime > 10.2f ) {
            canvas.enabled = false;
        }
    }
}
