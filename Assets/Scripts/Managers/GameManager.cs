using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField]
    private GameEvent spawnAsteroidsEvent;

    [field: SerializeField]
    public GameObjectRuntimeSet asteroidSet;

    public int asteroids;
    private bool isQuitting = false;

    [SerializeField]
    GameObject asteroidObject;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Debug.LogError("Duplicate GameManager found!");
        }
    }

    // Update is called once per frame
    void Update() {
        asteroids = asteroidSet.Count;

        if (asteroidSet.Count == 0 && !isQuitting)
        {
            spawnAsteroidsEvent.Raise();
        }

    }

    public void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public static void SpawnAsteroids(int count) {
        if (count <= 0) return;
        for (int i = 0; i < count; i++) {
            Instantiate(instance.asteroidObject, ScreenBounds.GetRandomPosition(), Quaternion.identity);
        }
    }

    public static void SpawnAsteroids()
    {
        int count = Random.Range(1, 5);
        for (int i = 0; i < count; i++)
        {
            Instantiate(instance.asteroidObject, ScreenBounds.GetRandomPosition(), Quaternion.identity);
        }
    }
}
