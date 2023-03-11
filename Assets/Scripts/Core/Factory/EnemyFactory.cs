using Assets.Scripts.Core.Utils;
using System;
using UnityEngine;
public class EnemyFactory
{
    private const byte QUANTITY_OBJECTS = 50;
    private Transform _parentForPoolObjects;
    private PoolableObject _objectPrefab;
    private ObjectPool<Enemy> _objectsPool;

    public EnemyFactory(Transform parentForPoolObjects, PoolableObject objectPrefab)
    {
        _parentForPoolObjects = parentForPoolObjects;
        _objectPrefab = objectPrefab;
        _objectsPool = new ObjectPool<Enemy>(_objectPrefab, QUANTITY_OBJECTS, _parentForPoolObjects);
        ScreenBoundary.Instance.LeftWorld += _objectsPool.ReturnObjectToPool;
    }

    public event Action<Enemy> EnemyDeath;

    public void SpawnEnemy(float spawnHeight)
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(ScreenBoundary.Instance.xMin, 
                                                                     ScreenBoundary.Instance.xMax),
                                                                     0,
                                                                     spawnHeight);

        Enemy spawnedEnemy = (Enemy)_objectsPool.GetObject(spawnPosition);

        spawnedEnemy.EnemyDeath += AnounceEntityDeath;
    }

    public void AnounceEntityDeath(Enemy enemy)
    {
        EnemyDeath?.Invoke(enemy);
        _objectsPool.ReturnObjectToPool(enemy);
    }
}

