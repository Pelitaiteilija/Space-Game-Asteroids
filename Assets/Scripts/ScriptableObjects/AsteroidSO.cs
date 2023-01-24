using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Asteroid SO")]
public class AsteroidSO : ScriptableObject {

    [field: SerializeField]
    public int maxHitpoints { get; private set; } = 1;
    [field: SerializeField]
    public Sprite sprite { get; private set; }
    [SerializeField]
    [Range(0.1f, 10f)]
    private float scale = 1f;
    [field: SerializeField]
    public List<SpawnEventSO> spawnObjectsOnDestroyed { get; private set; }
    [field: SerializeField]
    public List<SpawnEventSO> spawnGoodiesOnDestroyed { get; private set; }

    public SpawnEventSO SpawnObjects() {
        return spawnObjectsOnDestroyed[Random.Range(0, spawnObjectsOnDestroyed.Count)];
    }

    public SpawnEventSO SpawnGoodies() {
        return spawnGoodiesOnDestroyed[Random.Range(0, spawnObjectsOnDestroyed.Count)];
    }


}
