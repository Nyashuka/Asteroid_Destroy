using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.DataStructures;
using System;
using UnityEngine;

public class Enemy : PoolableObject, IDamageable, IDestroyable
{
    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private int _healthAmount;

    private Health _enemyHealth;
    public event Action<Enemy> EnemyDeath;

    public EnemyTypes EnemyType => _enemyType;

    public void Start()
    {
        _enemyHealth = new Health(_healthAmount);
        _enemyHealth.Death += AnounceDeath;
    }

    private void OnDisable()
    {
        EnemyDeath = null;
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

    public void MakeDamage(int damage)
    {
        _enemyHealth.DecreaseHealth(damage);
    }
}
