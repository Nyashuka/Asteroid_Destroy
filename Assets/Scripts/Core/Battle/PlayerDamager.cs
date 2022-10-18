using System;
using System.Threading;
using UnityEngine;

public abstract class PlayerDamager : MonoBehaviour
{
    public event Action<Enemy> Killed;

    public void SetKillAction(Action<Enemy> killAction)
    {
        Killed = killAction;
    }

    public void OnTriggerEnter(Collider other)
    {      
        if(other.gameObject.TryGetComponent(out Enemy damageable))
        {            
            if(!damageable.TryDamageOrKill())
            {               
                Killed?.Invoke(damageable);    
                Destroy(damageable);
            }
        }
    }
}

