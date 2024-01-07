using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BarChart : MonoBehaviour
{
    public Bar barPrefab;
    public int[] inputValues;
    public string[] labels; //braucht man nicht unbedingt
    public Color[] colors;

    List<Bar> bars = new List<Bar>();

    float chartHeight;

    void Start()
    {
        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y; //sizeDelta.y: differenz in top und botton
        DisplayGraphs(inputValues);
    }

    void Update()
    {
        //nach jeder änderung bei der anzahl von viren in den teams werden die graphs neu gezeichnet:
        //

    }

    void DisplayGraphs(int[] graphValues)
    {
        int maxValue = graphValues.Max();

        for (int i = 0; i < graphValues.Length; i++)
        {
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform); //dass der Balken nd irgendwo ist

            //Barhöhe anpassen:
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            float normalizedValue = ((float)graphValues[i] / maxValue) * 0.98f; //Zahl angepasst zwischen 0 und 1
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHeight * normalizedValue); //später: graphvalues normalisieren --> zwischen 0&1 
            newBar.bar.color = colors[i % colors.Length];

            //Bar Label/Value:
            newBar.label.text = $"Team {i + 1}";
            newBar.value.text = graphValues[i].ToString();

            //wenn die höhe vom balken zu klein ist, muss die zahl über den balken
            if(rt.sizeDelta.y < 50f)
            {
                newBar.value.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
                newBar.value.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        }
    }
}

/*if (labels.Length <= i)
{
    newBar.label.text = "UNDEFINED";
}
else
{
    newBar.label.text = $"Team {i + 1}";
}*/