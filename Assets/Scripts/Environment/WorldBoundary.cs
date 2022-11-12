using System;
using UnityEngine;

public class WorldBoundary : MonoBehaviour
{
    public event Action<PoolableObject> LeftWorld;

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PoolableObject poolable))
            LeftWorld?.Invoke(poolable);
    }
}
