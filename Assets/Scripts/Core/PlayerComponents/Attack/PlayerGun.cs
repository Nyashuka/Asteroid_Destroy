using Assets.Scripts.Core.PlayersComponents.Attack;
using Assets.Scripts.Core.PlayersComponents.Attack.Abstract;
using Assets.Scripts.Services;
using Core.Battle;
using Core.Services.ServiceLocatorSystem;
using UnityEngine;
using Utils;

namespace Core.PlayerComponents.Attack
{
    public class PlayerGun
    {
        private readonly Bullet _bulletPrefab;
        private readonly Transform _bulletSpawnPosition;
        private readonly float _attackCooldown = 0.5f;
        private readonly int _countBulletsInPool = 10;

        private readonly Transform _parentForPoolObjects;

        private ObjectPool<Bullet> _bulletPool;

        private float _nextAttackTime = 0;

        private IPlayerAttack _playerAttack;

        public IPlayerAttack PlayerAttack => _playerAttack;

        public PlayerGun(Bullet bulletPrefab, Transform bulletSpawnPosition)
        {
            _bulletPrefab = bulletPrefab;
            _bulletSpawnPosition = bulletSpawnPosition;

            _parentForPoolObjects = new GameObject("Parent_For_Bullets_Pool").transform;
            _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _countBulletsInPool, _parentForPoolObjects);
            ServiceLocator.Instance.GetService<ScreenBoundary>().LeftWorld += ReturnBulletToPool;

            _playerAttack = new SimplePlayerAttack();
        }

        public void Attack()
        {
            if (_nextAttackTime > Time.time)
                return;

            _nextAttackTime = Time.time + _attackCooldown;

            if (Input.GetMouseButton(0) || Input.touchCount == 1)
            {
                _playerAttack.Attack(_bulletPool, _bulletSpawnPosition.position);
            }
        }

        private void ReturnBulletToPool(IDestroyable destroyable)
        {
            if (destroyable is PoolableObject poolableObject)
                _bulletPool.ReturnObjectToPool(poolableObject);
        }

        public void ChangeAttackImplementation(IPlayerAttack attackImplementation)
        {
            _playerAttack = attackImplementation;
        }
    }
}
