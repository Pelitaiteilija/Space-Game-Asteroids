using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Subscribe this listener to this GameEvent asset")]
    [SerializeField]
    private GameEvent Event;

    [Tooltip("Unity Events that will be invoked when the GameEvent is raised")]
    [SerializeField]
    private UnityEvent Response;

    public void OnEventRaised()
    {
        Response?.Invoke();
    }

    private void OnEnable()
    {
        if (Event != null) Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (Event != null) Event.UnregisterListener(this);
    }
}

public class GameEventListener<T> : MonoBehaviour
{
    [Tooltip("Subscribe this listener to this GameEvent asset")]
    [SerializeField]
    private GameEvent<T> Event;

    [Tooltip("Unity Events that will be invoked when the GameEvent is raised")]
    [SerializeField]
    private UnityEvent<T> Response;

    public void OnEventRaised(T value)
    {
        Response?.Invoke(value);
    }

    private void OnEnable()
    {
        if (Event != null) Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (Event != null) Event.UnregisterListener(this);
    }
}
