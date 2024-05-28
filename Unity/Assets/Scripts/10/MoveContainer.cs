using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MoveContainer : MonoBehaviour
{
    /*[SerializeField] Transform[] positions;
    [SerializeField] bool shouldBeDeleted;

    

    private int nextPositionIndex;
    private Transform nextPosition;
    private bool isMoving = true;

    private Transform chest;

    void Start()
    {
        nextPosition = positions[0];
        chest = GameObject.FindGameObjectWithTag("Chest").transform;
        chest.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isMoving)
        {
            MoveContainerToNextPosition();
        } 
       else
        {
            StartBigContainerAnimation();
        }
    }

    void MoveContainerToNextPosition()
    {
        if(Vector3.Distance(transform.position, nextPosition.position) < 0.1f)
        {
            nextPositionIndex++;
            if(nextPositionIndex >= positions.Length)
            {
                isMoving = false;
                if(shouldBeDeleted)
                {
                    Destroy(gameObject);
                }
                return;
            }
            nextPosition = positions[nextPositionIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, 1 * Time.deltaTime);
        }
    }

    void StartBigContainerAnimation()
    {
        chest.gameObject.SetActive(true);

        float scaleSpeed = 0.05f;

        Vector3 originalScale = chest.localScale; 
        Vector3 targetScale = originalScale * 100f;

        chest.localScale = Vector3.Lerp(chest.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }*/
}
