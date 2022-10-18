using UnityEngine;

public abstract class Enemy : PoolableObject, IDamageable, IScorable
{
    [SerializeField] private Health _enemyHealth;

    public bool TryDamageOrKill()
    {
        _enemyHealth.DecreaseHealth();

        return _enemyHealth.CurrentHealth <= 0;
    }
}
