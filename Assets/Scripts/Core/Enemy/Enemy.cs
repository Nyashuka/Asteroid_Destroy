using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable, IScorable
{
    [SerializeField] private Health _enemyHealth;

    public bool TryDamageOrKill()
    {
        _enemyHealth.DecreaseHealth();

        return _enemyHealth.CurrentHealth < 0;
    }
}
