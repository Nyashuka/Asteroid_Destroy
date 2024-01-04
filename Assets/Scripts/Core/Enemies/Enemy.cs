using System;
using Assets.Scripts.Services;
using Core.Battle;
using Core.Battle.Abstract;
using UnityEngine;
using Utils;

namespace Core.Enemies
{
    public class Enemy : PoolableObject, IDamageable, IDestroyable
    {
        [SerializeField] private EnemyTypes enemyType;
        [SerializeField] private GameObject deathVFX;
        [SerializeField] private int healthAmount;
        [SerializeField] private int damageAmount;

        private Health _enemyHealth;
        private IDamager _damager;
        public event Action<Enemy> EnemyDeath;

        public EnemyTypes EnemyType => enemyType;

        public void Start()
        {
            _enemyHealth = new Health(healthAmount);
            _enemyHealth.Death += AnnounceDeath;
            _damager = new SimpleDamager(damageAmount);
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

        private void AnnounceDeath()
        {
            Destroy(Instantiate(deathVFX, transform.position, transform.rotation), 1f);
            EnemyDeath?.Invoke(this);
        }

        public void MakeDamage(int damage)
        {
            _enemyHealth.DecreaseHealth(damage);
        }
    }
}
