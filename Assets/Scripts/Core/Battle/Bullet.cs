using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{
    public event Action HitEvent;

    private BulletPoolNoMonoBeh _bulletPool;
    private IDamager _damager;

    public void Init(BulletPoolNoMonoBeh bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            _damager.TryDamage(damageable.GetDamage());
            HitEvent?.Invoke();
        }
    }
}

