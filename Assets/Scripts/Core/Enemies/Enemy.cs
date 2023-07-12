using System;
using Assets.Scripts.Core.Battle;
using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Services;
using UnityEngine;
using Utils;

namespace Core.Enemies
{
    public class Enemy : PoolableObject, IDamageable, IDestroyable
    {
        [SerializeField] private EnemyTypes _enemyType;
        [SerializeField] private GameObject _deathVFX;
        [SerializeField] private int _healthAmount;
        [SerializeField] private int _damageAmount;

        private Health _enemyHealth;
        private IDamager _damager;
        public event Action<Enemy> EnemyDeath;

        public EnemyTypes EnemyType => _enemyType;

        public void Start()
        {
            _enemyHealth = new Health(_healthAmount);
            _enemyHealth.Death += AnounceDeath;
            _damager = new SimpleDamager(_damageAmount);
        }

        private void OnDisable()
        {
            EnemyDeath = null;
        }

        public void OnTriggerEnter(Collider collider)
        {
            _damager.DoDamage(collider);
        }

        public void Init()
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
}
