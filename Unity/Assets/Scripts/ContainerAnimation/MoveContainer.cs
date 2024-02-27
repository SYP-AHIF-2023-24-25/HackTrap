using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveContainer : MonoBehaviour
{
    [SerializeField] Transform[] positions;

    private int nextPositionIndex;
    private Transform nextPosition;
    private bool isMoving = true;

    void Start()
    {
        nextPosition = positions[0];
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
                Destroy(gameObject);
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

    }
}
