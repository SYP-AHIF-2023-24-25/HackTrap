using DeepSpace.LaserTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColissionScript : MonoBehaviour
{
    private bool _collided = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        _collided = true;

        yield return new WaitForSeconds(3); // Wait for 3 seconds to check, if someone is still standing on the button.
        if (_collided == true) // check, if someone is still on the button
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _collided = false;
    }
}
