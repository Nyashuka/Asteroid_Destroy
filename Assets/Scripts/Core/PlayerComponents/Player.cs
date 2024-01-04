using System;
using Assets.Scripts.Core.PlayersComponents.Attack.Abstract;
using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Core.Battle;
using Core.Battle.Abstract;
using Core.Pause;
using Core.PlayerComponents.Attack;
using Core.PlayerComponents.Bonuses;
using Core.PlayersComponents.Bonuses;
using Core.Services;
using Core.Services.ServiceLocatorSystem;
using Services;
using UnityEngine;

namespace Core.PlayerComponents
{
    public class Player : MonoBehaviour, IHealeable, IDamageable, IPauseHandler
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletSpawnPosition;
        [SerializeField] private GameObject deathVFX;
        [SerializeField] private int healthAmount;
        [SerializeField] private int speed;

        private Health _health;
        private PlayerMove _playerMove;
        private PlayerGun _playerGun;
        private BuffsContainer _buffsContainer;
        private IDamageable _damageable;

        private bool _isPaused;

        public event Action DeathEvent;

        private void Start()
        {
            _playerGun = new PlayerGun(bulletPrefab, bulletSpawnPosition);
            _playerMove = new PlayerMove(transform, speed);
            _health = new Health(healthAmount);
            _damageable = new SimpleDamageable(_health);
            _health.Death += OnDeath;

            var playerViewContainer = ServiceLocator.Instance.GetService<PlayerViewContainer>();
            playerViewContainer.HealthBar.Init(_health);
            var buffIndicator = playerViewContainer.BuffIndicator;
            _buffsContainer = new BuffsContainer(this, buffIndicator);
        }

        private void Update()
        {
            if (_isPaused) return;

            _playerGun.Attack();
            _playerMove.Move();
            _buffsContainer.UseBuffs();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BuffContainer buffContainer))
            {
                _buffsContainer.AddBuff(buffContainer);
            }
        }

        private void OnDeath()
        {
            Destroy(Instantiate(deathVFX, transform.position, transform.rotation), 1f);
            AnnounceDeath();
        }

        public void Heal()
        {
            _health.IncreaseHealth();
        }

        private void AnnounceDeath()
        {
            DeathEvent?.Invoke();
        }

        public void MakeDamage(int damage)
        {
            _damageable.MakeDamage(damage);
        }

        public void ChangeDamageable(IDamageable damageable)
        {
            _damageable = damageable;
        }

        public void SetBuff(ShieldBuff buff)
        {
            buff.Init(this, _damageable, _health);
        }

        public void SetBuff(MultiShotBuff buff)
        {
            buff.Init(this, _playerGun.PlayerAttack);
        }

        public void SetBuff(HealBuff buff)
        {
            buff.Init(this);
        }

        public void ChangeAttackImplementation(IPlayerAttack attackImplementation)
        {
            _playerGun.ChangeAttackImplementation(attackImplementation);
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }

        private void OnEnable()
        {
            ServiceLocator.Instance.GetService<PauseManager>().Register(this);
        }
        private void OnDisable()
        {
            ServiceLocator.Instance.GetService<PauseManager>().UnRegister(this);
        }
    }
}


