using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Asteroid : MonoBehaviour, IAmDamageable
{
    public AsteroidSizeTier size { get; private set; } = AsteroidSizeTier.Large;

    [SerializeField]
    private float hitpoints = 10f;

    private Vector2 movement = Vector2.zero;
    private Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
        transform.Rotate(rotation * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        Debug.Log($"Asteroid was hit and took {amount} damage!");
        hitpoints -= amount;
        if (hitpoints <= 0)
            Destroy(gameObject);
    }

    public void OnDestroy()
    {
        Debug.Log("Asteroid destroyed");
    }
}


public enum AsteroidSizeTier
{
    Large, Medium, Small
}