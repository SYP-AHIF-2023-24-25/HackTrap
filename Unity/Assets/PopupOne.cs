using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

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
        sceneRuntime = Time.time;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        Invoke("showCanvas", time);
    }

    void showCanvas()
    {
        canvas.enabled = true;
        GetComponent<Canvas>().GetComponent<RectTransform>().anchoredPosition = new Vector2(positionX, positionY);
    }

    // Update is called once per frame
    void Update()
    {
        sceneRuntime = Time.time - sceneRuntime;

        UnityEngine.Debug.Log("Runtime: " + sceneRuntime);

        if(sceneRuntime > 11f ) {
            canvas.enabled = false;
        }
    }
}
