using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Asteroid SO")]
public class AsteroidSO : ScriptableObject {

    // max hitpoints of the asteroid
    [field: SerializeField]
    public int maxHitpoints { get; private set; } = 1;

    // sprite to be used for the asteroid 
    // TODO: add a list from which one is picked
    [field: SerializeField]
    public Sprite sprite { get; private set; }

    // converted to uniform Vec3 scale transform
    [field: SerializeField]
    [field: Range(0.1f, 10f)]
    public float scale { get; private set; } = 1f;

    [field: SerializeField]
    [field: Range(0.0f, 0.5f)]
    public float scaleVariation { get; private set; } = 0.1f;

    // select one of the listed objects to be spawned when object is destroyed, if at least one exist
    [field: SerializeField]
    public List<SpawnEventSO> spawnObjectsOnDestroyed { get; private set; }

    // select one of the listed goodies to be spawned when object is destroyed, if at least one exist
    [field: SerializeField]
    public List<SpawnEventSO> spawnGoodiesOnDestroyed { get; private set; }

    public SpawnEventSO SpawnObjects() {
        return spawnObjectsOnDestroyed[Random.Range(0, spawnObjectsOnDestroyed.Count)];
    }

    public SpawnEventSO SpawnGoodies() {
        return spawnGoodiesOnDestroyed[Random.Range(0, spawnObjectsOnDestroyed.Count)];
    }


}
