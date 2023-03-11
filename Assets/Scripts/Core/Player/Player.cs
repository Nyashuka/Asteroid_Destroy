using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Core.Player.Attack.Abstract;
using Assets.Scripts.Core.Player.Bonuses;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Player
{
    public class Player : MonoBehaviour, IHealeable, IDamageable
    {             
        [SerializeField] private BuffIndicator _buffIndicator;
        [SerializeField] private HealthBar _healthBar;
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

        private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

        public event Action DeathEvent;
        

        private void Start()
        {
            _playerGun = new PlayerGun(_bulletPrefab, _bulletSpawnPosition);
            _playerMove = new PlayerMove(transform, _speed);
            _health = new Health(_healthAmount);
            _healthBar.Init(_health);
            _damageable = new SimpleDamageable(_health);
            _buffsContainer = new BuffsContainer(this, _buffIndicator);
            _health.Death += OnDeath;
        }

        private void Update()
        {
            if (IsPaused)
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
    }
}


