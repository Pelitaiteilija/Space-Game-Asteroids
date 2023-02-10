using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GameEvents/GameEvent", fileName ="Event_EventName")]
public class GameEvent : ScriptableObject
{

    private List<GameEventListener> listeners =
        new();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
            return;
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}

public class GameEvent<T> : ScriptableObject
{
    private List<GameEventListener<T>> listeners =
        new();

    public void Raise(T value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameEventListener<T> listener)
    {
        if (listeners.Contains(listener))
            return;
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}
