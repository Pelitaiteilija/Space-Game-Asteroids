using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/ViewZoomerSO")]
public class ViewZoomerSO : ScriptableObject
{
    [field: SerializeField] public float minimumZoom { get; private set; } = 1f;
    [field: SerializeField] public float maximumZoom { get; private set; } = 20f;
}
