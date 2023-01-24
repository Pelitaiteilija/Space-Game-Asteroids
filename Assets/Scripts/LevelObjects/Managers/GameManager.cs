using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private static int asteroidsCount = 0;
    private bool isQuitting = false;

    [SerializeField]
    GameObject asteroidObject;

    [SerializeField]
    int asteroids;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Debug.LogError("Duplicate GameManager found!");
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        asteroids = asteroidsCount;

        if (asteroidsCount == 0 && !isQuitting)
        {
            SpawnAsteroids(Random.Range(1, 5));
        }

    }

    public void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public static void AsteroidCountIncrement() {
        asteroidsCount++;
    }

    public static void AsteroidCountDecrease() {
        asteroidsCount--;
        if (asteroidsCount < 0) {
            asteroidsCount = 0;
            Debug.LogWarning("asteroidsCount was negative!");
        }

    }

    public static void SpawnAsteroids(int count) {
        for (int i = 0; i < count; i++) {
            Instantiate(instance.asteroidObject, ScreenBounds.GetRandomPosition(), Quaternion.identity);
        }
    }
}
