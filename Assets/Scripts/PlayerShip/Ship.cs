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
    private float forwardThrust = 10f;
    [SerializeField]
    private float breakForce = 0.5f;

    private ShipStats shipStats;

    private void Awake()
    {
        playerInput = GetComponent<ShipInputHandler>();
        shipStats = GetComponent<ShipStats>();
    }

    public float CalculateRotation()
    {
        return playerInput.rotationInput * rotationSpeed *shipStats.rotationMultiplier * Time.deltaTime;
    }

    public float CalculateThrust()
    {
        return playerInput.thrustForceInput * forwardThrust *shipStats.movementMultiplier * Time.deltaTime;
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

        transform.Rotate(Vector3.back, shipRotation);
        transform.Translate(transform.up * shipThrust, Space.World);

        if(Mathf.Abs(shipThrust) < 0.05f ) {
            shipStats.ReplaceStat(Stats.attackSpeed, 3.0f);
        }
        else {
            shipStats.ReplaceStat(Stats.attackSpeed, 1.0f);
        }
    }
}
