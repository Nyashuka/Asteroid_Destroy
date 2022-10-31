using System;
using UnityEngine;

public class Bullet : PoolableObject
{
    public event Action<Bullet> Hit;

    public override void Init()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy damageable))
        {
            damageable.TryDamage();
            Hit?.Invoke(this);
        }
    }
}

