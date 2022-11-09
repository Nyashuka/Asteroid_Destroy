using System;
using UnityEngine;

public class Enemy : PoolableObject, IDamageable
{
    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private GameObject _deathVFX;

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
        Destroy(Instantiate(_deathVFX, transform.position, transform.rotation), 1f);
        EnemyDeath?.Invoke(this);
    }

    public void GetDamage()
    {
        _enemyHealth.DecreaseHealth();
    }
}
