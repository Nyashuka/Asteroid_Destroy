using System;
using UnityEngine;

public class Enemy : PoolableObject, IDamageable
{
    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] private Health _enemyHealth;
    public event Action<Enemy> EnemyDeath;
    public EnemyTypes EnemyType => _enemyType;

    public void Start()
    {
        _enemyHealth.Death += AnounceDeath;
    }

    public override void Init()
    {
        _enemyHealth.Reset();
    }

    public void AnounceDeath()
    {
        EnemyDeath?.Invoke(this);
    }

    public void GetDamage()
    {
        _enemyHealth.DecreaseHealth();
    }
}
