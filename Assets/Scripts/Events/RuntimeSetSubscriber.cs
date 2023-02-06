using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSetSubscriber: MonoBehaviour
{
    [field: SerializeField]
    public GameObjectRuntimeSet gameObjectRuntimeSet { get; private set; }

    private void OnEnable()
    {
        gameObjectRuntimeSet.AddToList(this.gameObject);
    }

    private void OnDisable()
    {
        gameObjectRuntimeSet.RemoveFromList(this.gameObject);
    }
}
