using System;
using System.Collections;
using UnityEngine;


public class EnemyFactory : MonoBehaviour 
{
    [SerializeField] private GameObject _parentForPoolObjects;
    [SerializeField] private Asteroid[] _asteroidPrefabs;
    [Header("Timings")]
    [SerializeField] private float _pauseBeforeFirstWave = 5;
    [SerializeField] private float _spawnRate = 0.5f;
    [SerializeField] private float _waveRate = 2;
    [SerializeField] private float _returnTime = 10f;
    [Header("Count")]
    [SerializeField] private int _asteroidsInWaveMin = 10;
    [SerializeField] private int _asteroidsInWaveMax = 50;
    [Header("Boundaries")]
    [SerializeField] private float _spawnHeight = 12;
    [SerializeField] private Boundary _spawnBoundary;

    public event Action<Enemy> EnemyDeath;

    [SerializeField] private Enemy _objectPrefab;
    private ObjectPool _objectsPool;

    public void Start()
    {
        _objectsPool = new ObjectPool(_objectPrefab, 50, _parentForPoolObjects);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_pauseBeforeFirstWave);

        while (true)
        {
            int countAsteroids = UnityEngine.Random.Range(_asteroidsInWaveMin, _asteroidsInWaveMax);

            for (int i = 0; i < countAsteroids; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_spawnBoundary.xMin, _spawnBoundary.xMax), 0, _spawnHeight);
                //Quaternion spawnRotation = Quaternion.identity;

                PoolableObject spawnEnemy = _objectsPool.GetObject(spawnPosition);
                spawnEnemy.Init();
                ((Enemy)spawnEnemy).EnemyDeath += AnounceEntityDeath;
                StartCoroutine(ReturnBulletWithTime(spawnEnemy, _returnTime));
                

                yield return new WaitForSeconds(_spawnRate);
            }

            yield return new WaitForSeconds(_waveRate);
        }
    }

    public void AnounceEntityDeath(Enemy enemy)
    {
        EnemyDeath?.Invoke(enemy);
        _objectsPool.ReturnObjectToPool(enemy);
    }

    private IEnumerator ReturnBulletWithTime(PoolableObject objectToReturn, float timeForReturn)
    {
        yield return new WaitForSeconds(timeForReturn);

        _objectsPool.ReturnObjectToPool(objectToReturn);
    }
}

