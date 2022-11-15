using Assets.Scripts.Core.Battle.Abstract;
using System;
using UnityEngine;

public class Bullet : PoolableObject
{
    public event Action<PoolableObject> Hit;

    public override void Init()
    {
      
    }

    private void OnDisable()
    {
        Hit = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.MakeDamage(1);
            Hit?.Invoke(this);
        }
    }
}

