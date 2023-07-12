using System;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Enemies;
using Services.EventBusService;
using Services.ServiceLocatorSystem;
using UnityEngine;
using Utils;

namespace Core.Factory
{
    public class EnemyFactory : IService
    {
        private const byte QuantityObjects = 50;
        private readonly Transform _parentForPoolObjects;
        private readonly PoolableObject _enemyPrefab;
        private readonly ObjectPool<Enemy> _objectsPool;
        private readonly ScreenBoundary _screenBoundary;
        private readonly EventBus _eventBus;

        public EnemyFactory(PoolableObject objectPrefab, ScreenBoundary boundary, EventBus eventBus)
        {
            _parentForPoolObjects = new GameObject("parent_for_pooled_enemies").transform;
            _enemyPrefab = objectPrefab;
            _objectsPool = new ObjectPool<Enemy>(_enemyPrefab, QuantityObjects, _parentForPoolObjects);
            _screenBoundary = boundary;
            _screenBoundary.LeftWorld += ReturnObjectToPool;
            _eventBus = eventBus;
        }

        public event Action<Enemy> EnemyDeath;

        public void Create(float spawnHeight)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_screenBoundary.xMin,
                    _screenBoundary.xMax),
                0,
                spawnHeight);

            Enemy spawnedEnemy = (Enemy)_objectsPool.GetObject(spawnPosition);

            spawnedEnemy.EnemyDeath += AnnounceEntityDeath;
        }

        private void ReturnObjectToPool(IDestroyable destroyable)
        {
            if (destroyable is PoolableObject poolable)
                _objectsPool.ReturnObjectToPool(poolable);
        }

        private void AnnounceEntityDeath(Enemy enemy)
        {
            EnemyDeath?.Invoke(enemy);
            _objectsPool.ReturnObjectToPool(enemy);
        }
    }
}

