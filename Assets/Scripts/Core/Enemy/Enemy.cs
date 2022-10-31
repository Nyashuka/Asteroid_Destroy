using System;
using UnityEngine;

public class Enemy : PoolableObject
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

    public void TryDamage()
    {
        _enemyHealth.DecreaseHealth();
    }

    public void AnounceDeath()
    {
        EnemyDeath?.Invoke(this);
    }

 
}
