using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour, IHaveStats {

    [field: SerializeField]
    public int attackPower { get; private set; } = 3;
    [field: SerializeField]
    public float attackSpeed { get; private set; } = 1.0f;
    [field: SerializeField]
    public int hullPoints { get; private set; } = 3;
    [field: SerializeField]
    public float movementMultiplier { get; private set; } = 1.0f;
    [field: SerializeField]
    public float rotationMultiplier { get; private set; } = 1.0f;

    public void ChangeStat(Stats targetStat, float amount)
    {
        switch(targetStat)
        {
            case Stats.attackPower:
                attackPower += (int)amount;
                break;
            case Stats.attackSpeed:
                attackSpeed += amount;
                break;
            case Stats.hullPoints:
                hullPoints += (int)amount;
                break;
            case Stats.movement:
                movementMultiplier += amount;
                break;
            case Stats.rotation:
                rotationMultiplier += amount;
                break;
            default:
                Debug.LogWarning($"Found unexpected stat type: {targetStat}");
                break;
        }
    }

    public void ReplaceStat(Stats targetStat, float amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Stat was changed to 0 or a negative value!");
        }
        switch (targetStat)
        {
            case Stats.attackPower:
                attackPower = (int)amount;
                break;
            case Stats.attackSpeed:
                attackSpeed = amount;
                break;
            case Stats.hullPoints:
                hullPoints = (int)amount;
                break;
            case Stats.movement:
                movementMultiplier = amount;
                break;
            case Stats.rotation:
                rotationMultiplier = amount;
                break;
            default:
                Debug.LogWarning($"Found unexpected stat type: {targetStat}");
                break;
        }
    }
}
