using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }

    public void SetFill()
    {
        float fillAmount = ((float)current + 1) / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
