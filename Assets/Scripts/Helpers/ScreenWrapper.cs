using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    public bool destroyWhenOutsideOfBounds = false;

    // Update is called once per frame
    void Update()
    {
        if (ScreenBounds.AmIOutOfBounds(transform.position))
        {
            if (destroyWhenOutsideOfBounds)
            {
                Destroy(gameObject);
            }

            transform.position = ScreenBounds.CalculateScreenWrapPosition(transform.position);
        }
    }
}
