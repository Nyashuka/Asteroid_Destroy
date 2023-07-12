using Assets.Scripts.Services;
using UnityEngine;

namespace Utils
{
    public abstract class PoolableObject : MonoBehaviour, IDestroyable
    {
        protected bool IsReturnedInPool;    
    }
}

