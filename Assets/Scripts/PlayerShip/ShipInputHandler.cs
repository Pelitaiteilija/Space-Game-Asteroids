using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class ShipInputHandler : MonoBehaviour
{
    public float rotationInput { get; private set; } = 0f;
    public float thrustForceInput { get; private set; } = 0f;

    public bool breakInput { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        rotationInput = Input.GetAxis("Horizontal");
        thrustForceInput = Input.GetAxis("Vertical");
        if (thrustForceInput < 0f)
            rotationInput *= -1;
        breakInput = Input.GetKey(KeyCode.Space);
    }
}
