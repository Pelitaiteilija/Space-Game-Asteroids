using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipStats))]
[RequireComponent(typeof(Ship))]
public class ShipWeaponHandler : MonoBehaviour, ICanHaveWeapons
{
    public List<Weapon> weapons { get; private set; } = new List<Weapon>();

    private ShipStats shipStats;
    private Ship ship; 

    void Awake()
    {
        shipStats = GetComponent<ShipStats>();
        ship = GetComponent<Ship>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Weapon weapon in transform.GetComponentsInChildren<Weapon>())
        {
            addWeapon(weapon);
        }
        Debug.Log($"List of weapons on ship: {weapons.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        updateWeapons();
    }

    public void updateWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.Tick(Time.deltaTime * shipStats.attackSpeed, ship.movementVector);
        }
    }

    public void addWeapon(Weapon weapon)
    {
        if (!weapons.Contains(weapon))
            weapons.Add(weapon);
    }

    public void removeWeapons()
    {
        weapons.Clear();
    }


}
