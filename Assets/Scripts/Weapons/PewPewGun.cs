using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPewGun : Weapon
{
    [SerializeField]
    private GameObject bullet;


    // Update is called once per frame
    public override void Activate(float shipThrust)
    {
        base.Activate(shipThrust);
        GameObject instance = Instantiate(bullet, transform.position, transform.rotation);
        //instance.GetComponent<Bullet>().AddSpeed(shipThrust);

    }
}
