using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField]
    private float timer = 0f;

    [field: SerializeField]
    public float cooldown { get; private set; } = 0.5f;

    public void Tick(float tickTime, float shipThrust)
    {
        timer += tickTime;
        if(timer >= cooldown)
        {
            timer = 0f;
            Activate(shipThrust);
        }
    }

    public virtual void Activate(float shipThrust)
    {

    }
}
