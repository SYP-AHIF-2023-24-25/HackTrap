using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] bool shouldBeDeleted;

    public GameObject CubeGreen;
    public GameObject CubeYellow;
    public GameObject CubePink;
    public GameObject CubeBlue;

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
            MoveContainerToNextPosition( CubeGreen);
            MoveContainerToNextPosition( CubeYellow);
            MoveContainerToNextPosition( CubePink);
            MoveContainerToNextPosition( CubeBlue);
        }
        else
        {
            StartBigContainerAnimation();
        }
    }

    bool MoveContainerToNextPosition(GameObject gameObjectCube)
    {
        if (Vector3.Distance(gameObjectCube.transform.position, nextPosition.position) < 0.1f)
        {
            nextPositionIndex++;
            if (nextPositionIndex >= positions.Length)
            {
                isMoving = false;
                if (shouldBeDeleted)
                {
                    Destroy(gameObjectCube);
                    return true;
                }
                return false;
            }
            nextPosition = positions[nextPositionIndex];
        }
        else
        {
            gameObjectCube.transform.position = Vector3.MoveTowards(gameObjectCube.transform.position, nextPosition.position, 1 * Time.deltaTime);
        }
        return false;
    }

    void StartBigContainerAnimation()
    {
        chest.gameObject.SetActive(true);

        float scaleSpeed = 0.05f;

        Vector3 originalScale = chest.localScale;
        Vector3 targetScale = originalScale * 100f;

        chest.localScale = Vector3.Lerp(chest.localScale, targetScale, Time.deltaTime * scaleSpeed);

        StartCoroutine(DestroyAnimation());
    }

    private IEnumerator DestroyAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
