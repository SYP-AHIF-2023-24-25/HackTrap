using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;


public class ButtonAnimation : MonoBehaviour
{
    public Button btn;
    private void Start()
    {
        //btn.onClick.AddListener(delegate { ChangeImage(); });
        //btn.onClick.AddListener(delegate { Animation(); });
    }
    private void Animation()
    {
        GetComponent<Animator>().Play("ButtonAnimation");
    }

    public void PlayAnimation()
    {
        Debug.Log("Test");
        Animation();
    }
    
}
