using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/shipStats SO")]
public class ShipStats_SO : ScriptableObject
{
    [field: SerializeField]
    public int attackPower { get; private set; } = 1;
    [field: SerializeField]
    public float attackSpeed { get; private set; } = 1.0f;
    [field: SerializeField]
    public int hullPoints { get; private set; } = 3;
    [field: SerializeField]
    public float movementMultiplier { get; private set; } = 1.0f;
    [field: SerializeField]
    public float rotationMultiplier { get; private set; } = 1.0f;
}
