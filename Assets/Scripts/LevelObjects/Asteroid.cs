using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Asteroid : MonoBehaviour, IAmDamageable
{
    public AsteroidSizeTier size { get; private set; } = AsteroidSizeTier.Large;

    // used to prevent instantiating of object into Editor mode scene
    private bool isQuitting;
    private bool isAlive = true;

    [SerializeField]
    private float hitpoints = 10f;

    [SerializeField]
    private AsteroidSO data;

    private Vector2 movement = Vector2.zero;
    private float rotation;

    void Awake()
    {
        if (data == null)
        {
            Debug.LogError("Asteroid has no Asteroid SO data, variable is null!");
        }
        hitpoints = data.maxHitpoints;
        transform.localScale = Vector3.one * (data.scale + Random.Range(-data.scaleVariation, data.scaleVariation));
        // data.sprite
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        movement = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        rotation = Random.Range(-120, 120);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        // Debug.Log($"Asteroid was hit and took {amount} damage!");
        hitpoints -= amount;
        if (isAlive && hitpoints <= 0)
        {
            SpawnOnDestroyed();
            isAlive = false;
            HandleAsteroidDestruction();
        }
    }

    public void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void HandleAsteroidDestruction()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    public void SpawnOnDestroyed()
    {
        // use isQuitting to make sure objects are not spawned while the game is moving from Play mode to Editor mode
        // otherwise, asteroids might be added in the Editor scene!
        if (data.spawnObjectsOnDestroyed.Count > 0 && !isQuitting)
        {
            int number = Random.Range(0, data.spawnObjectsOnDestroyed.Count);
            SpawnEventSO spawnEvent = data.spawnObjectsOnDestroyed[number];
            spawnEvent.amount.Init();
            int amount = spawnEvent.amount.rollDice();
            //Debug.Log($"Spawning {amount} asteroids");
            for (int i = 0; i < amount; i++)
            {
                Instantiate(
                    spawnEvent.objectToSpawn,
                    transform.position + new Vector3(
                        Random.Range(-1f, 1f),
                        Random.Range(-1f, 1f),
                        0f),
                    Quaternion.identity
                    );
            }
        }
        if (data.spawnGoodiesOnDestroyed.Count > 0)
        {
        }
    }
}

public enum AsteroidSizeTier
{
    Large, Medium, Small
}