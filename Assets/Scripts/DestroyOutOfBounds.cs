using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 7;
    private float lowerBound = -6;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {

            //deactivate the projectile from pool
            gameObject.SetActive(false);

        }
        else if (transform.position.y < lowerBound)
        {
            gameObject.SetActive(false);
        }

    }
}
