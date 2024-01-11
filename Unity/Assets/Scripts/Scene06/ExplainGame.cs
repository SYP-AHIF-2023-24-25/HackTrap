using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class ExplainGame : MonoBehaviour
{
    private Text explanationText;

    string explanation = "Eliminate the viruses by collecting them to your teambase in the corners \n You can collect a maximum of five! \n Good luck! \n 3 \n 2 \n 1 ";

    private async void Awake()
    {
        explanationText = transform.Find("ExplanationText").GetComponent<Text>();
        Debug.Log(explanationText);
    }

    private void Start()
    {
        TextExplanation.AddWriterStatic(explanationText, explanation, .15f, false);
    }
}
