using System;
using System.Threading;
using UnityEngine;

public abstract class PlayerDamager : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {      
        if(other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage();  
        }
    }
}

