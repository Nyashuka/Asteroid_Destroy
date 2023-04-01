using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Core.PlayersComponents.Attack.Abstract;
using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents
{
    public class Player : MonoBehaviour, IHealeable, IDamageable, IPauseHandler
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;
        [SerializeField] private GameObject _deathVFX;
        [SerializeField] private int _healthAmount;
        [SerializeField] private int _speed;

        private Health _health;
        private PlayerMove _playerMove;
        private PlayerGun _playerGun;
        private BuffsContainer _buffsContainer;
        private IDamageable _damageable;

        private bool _isPaused;

        public event Action DeathEvent;

        private void Start()
        {
            _playerGun = new PlayerGun(_bulletPrefab, _bulletSpawnPosition);
            _playerMove = new PlayerMove(transform, _speed);
            _health = new Health(_healthAmount);
            _damageable = new SimpleDamageable(_health);
            _health.Death += OnDeath;

            UIMediator uIMediator = ServiceLocator.Instance.GetService<UIMediator>();
        }

        private void Update()
        {
            if (_isPaused)
                return;

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
            Destroy(Instantiate(_deathVFX, transform.position, transform.rotation), 1f);
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


