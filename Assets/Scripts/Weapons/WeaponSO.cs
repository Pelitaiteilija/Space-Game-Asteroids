using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSO : ScriptableObject
{
    [field: SerializeField]
    public float cooldown { get; private set; } = 0.5f;

    [field: SerializeField]
    public string weaponName { get; private set; }


    public virtual void Activate(Transform weaponTransform, Vector2 shipMovement)
    {
        
    }

}
