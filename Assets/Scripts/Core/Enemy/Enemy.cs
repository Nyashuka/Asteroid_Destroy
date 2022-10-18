using UnityEngine;

public class Enemy : PoolableObject, IDamageable, IScorable
{
    [SerializeField] private Health _enemyHealth;

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public bool TryDamageOrKill()
    {
        _enemyHealth.DecreaseHealth();

        return _enemyHealth.CurrentHealth <= 0;
    }
}
