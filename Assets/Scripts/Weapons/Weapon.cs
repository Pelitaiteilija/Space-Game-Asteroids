using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timer = 0f;

    [SerializeField]
    private WeaponSO weaponSO;

    public void Awake()
    {
        if(weaponSO == null) {
            this.enabled= false;
            Debug.LogError("Weapon has no Weapon SO, add a scriptable object!");
        }
    }

    public void Tick(float tickTime, Vector2 shipMovement)
    {
        timer += tickTime;
        if(timer >= weaponSO.cooldown)
        {
            timer = 0;
            Activate(shipMovement);
        }
    }

    public virtual void Activate(Vector2 shipMovement)
    {
        weaponSO.Activate(transform, shipMovement);
    }

    public string GetWeaponName()
    {
        return weaponSO.weaponName;
    }

    public override string ToString()
    {
        return GetWeaponName();
    }
}
