using System;
using System.Collections;
using UnityEngine;


public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _parentForPoolObjects;
    [SerializeField] private Asteroid[] _asteroidPrefabs;
    [Header("Timings")]
    [SerializeField] private float _pauseBeforeFirstWave = 5;
    [SerializeField] private float _spawnRate = 0.5f;
    [SerializeField] private float _waveRate = 2;
    [Header("Count")]
    [SerializeField] private int _asteroidsInWaveMin = 10;
    [SerializeField] private int _asteroidsInWaveMax = 50;
    [Header("Boundaries")]
    [SerializeField] private float _spawnHeight = 12;
    [SerializeField] private ScreenBoundary _spawnBoundary;
    [SerializeField] private WorldBoundary _boundary;
    [SerializeField] private PoolableObject _objectPrefab;

    private ObjectPool<Enemy> _objectsPool;

    public event Action<Enemy> EnemyDeath;
    public void Start()
    {
        _objectsPool = new ObjectPool<Enemy>(_objectPrefab, 50, _parentForPoolObjects);
        StartCoroutine(Spawn());
        _boundary.LeftWorld += _objectsPool.ReturnObjectToPool;


    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_pauseBeforeFirstWave);

        while (true)
        {
            int countAsteroids = UnityEngine.Random.Range(_asteroidsInWaveMin, _asteroidsInWaveMax);

            for (int i = 0; i < countAsteroids; i++)
            {
                SpawnEnemy();

                yield return new WaitForSeconds(_spawnRate);
            }

            yield return new WaitForSeconds(_waveRate);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_spawnBoundary.xMin, _spawnBoundary.xMax),
                                                            0,
                                                            _spawnHeight);

        Enemy spawnedEnemy = (Enemy)_objectsPool.GetObject(spawnPosition);

        spawnedEnemy.EnemyDeath += AnounceEntityDeath;
    }

    public void AnounceEntityDeath(Enemy enemy)
    {
        EnemyDeath?.Invoke(enemy);
        _objectsPool.ReturnObjectToPool(enemy);
    }
}

