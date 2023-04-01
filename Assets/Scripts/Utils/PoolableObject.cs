using Assets.Scripts.Services;
using System;
using UnityEngine;
public abstract class PoolableObject : MonoBehaviour, IDestroyable
{
    protected bool IsReturnedInPool;    
}

