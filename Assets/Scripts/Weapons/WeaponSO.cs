using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSO : ScriptableObject
{
    [field: SerializeField]
    public float cooldown { get; private set; } = 0.5f;


    public virtual void Activate(Transform weaponTransform, Vector2 shipMovement)
    {
        
    }

}
