using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour, IHaveStats {

    [SerializeField]
    ShipStats_SO shipStats_SO;

    public int attackPower { get; private set; }
    public float attackSpeed { get; private set; } 
    public int hullPoints { get; private set; }
    public float movementMultiplier { get; private set; }
    public float rotationMultiplier { get; private set; }

    public void Awake() {
        ResetStats();
    }

    public void ResetStats() {
        if(shipStats_SO == null) {
            Debug.LogError("Ship has no ShipStats_SO scriptable object!");
        }
        attackPower = shipStats_SO.attackPower;
        attackSpeed = shipStats_SO.attackSpeed;
        hullPoints = shipStats_SO.hullPoints;
        movementMultiplier = shipStats_SO.movementMultiplier;
        rotationMultiplier = shipStats_SO.rotationMultiplier;
    }

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
