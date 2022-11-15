using System;
using UnityEngine;
public abstract class PoolableObject : MonoBehaviour 
{
    protected bool IsReturnedInPool;
    public abstract void Init();

    
}

