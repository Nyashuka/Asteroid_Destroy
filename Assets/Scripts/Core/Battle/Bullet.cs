using System;
using UnityEngine;

public class Bullet : PoolableObject
{
    public event Action<PoolableObject> Hit;

    public override void Init()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage();
            Hit?.Invoke(this);
        }
    }
}

