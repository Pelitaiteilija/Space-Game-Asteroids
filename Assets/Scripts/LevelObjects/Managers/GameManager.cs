using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

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
            SpawnAsteroids(Random.Range(1, 5));
        }

    }

    public void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public static void SpawnAsteroids(int count) {
        for (int i = 0; i < count; i++) {
            Instantiate(instance.asteroidObject, ScreenBounds.GetRandomPosition(), Quaternion.identity);
        }
    }
}
