using UnityEngine;

public class VirusMovement: MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.65f;
    private Collider objectCollider;
    private Vector3 randomDirection;

    void Start()
    {
        randomDirection = GetRandomDirection().normalized; // Start moving in a random direction
    }

    void Update()
    {
        MoveObject();
        //CheckBoundsAndRedirect();  //Optional
    }

    public void Initialize(Collider collider)
    {
        objectCollider = collider;
    }

    private void MoveObject()
    {
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    private void CheckBoundsAndRedirect()
    {
        if (objectCollider != null && !objectCollider.bounds.Contains(transform.position))
        {
            randomDirection = GetRandomDirection().normalized; // Reverse direction if out of bounds
        }
    }

    private Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        return new Vector3(x, 0f, z);
    }
}
