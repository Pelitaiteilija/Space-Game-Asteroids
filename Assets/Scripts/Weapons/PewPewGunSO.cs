using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapons/PewPewGun")]
public class PewPewGunSO : WeaponSO
{
    [SerializeField]
    private GameObject bullet;


    // Update is called once per frame
    public override void Activate(Transform weaponTransform, Vector2 shipMovement)
    {
        base.Activate(weaponTransform, shipMovement);
        GameObject instance = Instantiate(bullet, weaponTransform.position, weaponTransform.rotation);
        instance.GetComponent<Bullet>().AddSpeed(shipMovement);
    }
}
