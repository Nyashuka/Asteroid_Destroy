using Assets.Scripts.Core.Utils;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using UnityEngine;
public class EnemyFactory : IService
{
    private const byte QUANTITY_OBJECTS = 50;
    private Transform _parentForPoolObjects;
    private PoolableObject _enemyPrefab;
    private ObjectPool<Enemy> _objectsPool;
    private ScreenBoundary _screenBoundary;

    public EnemyFactory(PoolableObject objectPrefab)
    {
        _parentForPoolObjects = new GameObject("parent_for_pooled_enemies").transform; ;
        _enemyPrefab = objectPrefab;
        _objectsPool = new ObjectPool<Enemy>(_enemyPrefab, QUANTITY_OBJECTS, _parentForPoolObjects);
        _screenBoundary = ServiceLocator.Instance.GetService<ScreenBoundary>();
        _screenBoundary.LeftWorld += ReturnObjectToPool; 
    }

    public event Action<Enemy> EnemyDeath;

    public void Create(float spawnHeight)
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_screenBoundary.xMin,
                                                                     _screenBoundary.xMax),
                                                                     0,
                                                                     spawnHeight);

        Enemy spawnedEnemy = (Enemy)_objectsPool.GetObject(spawnPosition);

        spawnedEnemy.EnemyDeath += AnounceEntityDeath;
    }

    private void ReturnObjectToPool(IDestroyable destroyable)
    {
        if (destroyable is PoolableObject poolable)
            _objectsPool.ReturnObjectToPool(poolable);
    }

    public void AnounceEntityDeath(Enemy enemy)
    {
        EnemyDeath?.Invoke(enemy);
        _objectsPool.ReturnObjectToPool(enemy);
    }
}

