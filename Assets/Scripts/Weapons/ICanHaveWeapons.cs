using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanHaveWeapons
{
    public List<Weapon> weapons { get; }
    public void updateWeapons();
    public void addWeapon(Weapon weapon);
    public void removeWeapons();
}
