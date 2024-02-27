using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class ExplainEncryptVirus : MonoBehaviour
{
    private Text explanationText;

    string explanation = "Please have the winning team come onto the field! \n You have successfully captured the entire virus \n To now free yourself from the virus, rearrange the letters in the correct order to form a word and kill the Virus! \n But be careful, the virus will free itself after 2 minutes. \n Good luck! \n 3 \n 2 \n 1 ";

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
