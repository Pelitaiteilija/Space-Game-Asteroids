using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments (E.g. Exit game event)
/// </summary>
[CreateAssetMenu(menuName = "Events/Void Event channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
