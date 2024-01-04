using System;
using Core.Battle.Abstract;
using UnityEngine;
using Utils;

namespace Core.Battle
{
    public class Bullet : PoolableObject
    {
        public event Action<PoolableObject> Hit;

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
}

