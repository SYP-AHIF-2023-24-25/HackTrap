using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyPharus : MonoBehaviour
{
    [SerializeField] public float speed;
    float vertical, horizontal;

    public RawImage mover;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f).normalized;

        // Move the RawImage
        MoveRawImage(moveDirection);

    }

    void MoveRawImage(Vector3 direction)
    {
        // Move the RawImage in the specified direction
        mover.rectTransform.position += direction * speed * Time.deltaTime;
    }
}
