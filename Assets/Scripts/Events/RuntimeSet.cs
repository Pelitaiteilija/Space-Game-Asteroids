using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();
    public int Count { get { return items.Count; } }

    public void Initialize()
    {
        items.Clear();
    }

    public T GetItemIndex (int index)
    {
        return items[index];
    }

    public void AddToList(T thing)
    {
        if (items.Contains(thing)) return;
        items.Add(thing);
    }

    public void RemoveFromList(T thing)
    {
        items.Remove(thing);
    }
}
