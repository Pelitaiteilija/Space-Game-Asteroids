using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("")]
[CreateAssetMenu(menuName = "Scriptable Objects/Spawn Event SO")]
public class SpawnEventSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject objectToSpawn { get; private set; }
    [field: SerializeField]
    public DiceNotation amount { get; private set; }

    public void Spawn(Transform target) {

    }
}
