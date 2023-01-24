using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Asteroid : MonoBehaviour, IAmDamageable {
    public AsteroidSizeTier size { get; private set; } = AsteroidSizeTier.Large;

    [SerializeField]
    private float hitpoints = 10f;

    private AsteroidSO data;

    private Vector2 movement = Vector2.zero;
    private float rotation;

    void Awake() {
        if (data == null) {
            Debug.LogError("Asteroid has no Asteroid SO data, variable is null!");
        }
        hitpoints = data.maxHitpoints;
        // data.sprite
    }

    // Start is called before the first frame update
    void Start() {
        movement = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        rotation = Random.Range(-120, 120);
        GameManager.AsteroidCountIncrement();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(movement * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
    }

    public void TakeDamage(float amount) {
        // Debug.Log($"Asteroid was hit and took {amount} damage!");
        hitpoints -= amount;
        if (hitpoints <= 0)
            Destroy(gameObject);
    }

    public void OnDestroy() {
        Debug.Log("Asteroid destroyed");
        GameManager.AsteroidCountDecrease();
        if (data.spawnObjectsOnDestroyed.Count > 0) {
            
        }
        if (data.spawnGoodiesOnDestroyed.Count > 0) {
        }
    }
}


public enum AsteroidSizeTier {
    Large, Medium, Small
}