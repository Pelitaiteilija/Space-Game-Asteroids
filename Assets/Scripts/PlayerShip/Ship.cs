using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ShipInputHandler))]
[RequireComponent(typeof(ShipStats))]
public class Ship : MonoBehaviour
{
    private ShipInputHandler playerInput;
    [SerializeField]
    private float rotationSpeed = 150f;
    [SerializeField]
    private float forwardThrust = 1f;
    [SerializeField]
    private float breakForce = 0.5f;

    public Vector2 movementVector { get; private set; } = Vector2.zero;

    private ShipStats shipStats;

    private void Awake()
    {
        playerInput = GetComponent<ShipInputHandler>();
        shipStats = GetComponent<ShipStats>();
    }

    public float CalculateRotation()
    {
        return playerInput.rotationInput * rotationSpeed * shipStats.rotationMultiplier;
    }

    public float CalculateThrust()
    {
        return playerInput.thrustForceInput * forwardThrust * shipStats.movementMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        float shipRotation  = CalculateRotation();
        float shipThrust    = CalculateThrust();
        if(playerInput.breakInput)
        {
            shipThrust *= breakForce;
        }

        transform.Rotate(Vector3.back, shipRotation * Time.deltaTime);

        // movementVector is changed based on facing and calculated thrust
        movementVector += (Vector2) (transform.up * shipThrust * Time.deltaTime);
        // vector value is halved every second
        movementVector *= 1.0f - (0.5f * Time.deltaTime);

        Debug.Log($"movementVector {movementVector}");
        transform.Translate(movementVector * Time.deltaTime, Space.World);
    }
}
