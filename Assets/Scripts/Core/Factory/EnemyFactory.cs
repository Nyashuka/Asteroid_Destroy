using System.Collections;
using UnityEngine;


public class EnemyFactory : MonoBehaviour 
{
    [SerializeField] private Asteroid[] _asteroidPrefabs;
    [Header("Timings")]
    [SerializeField] private float _pauseBeforeFirstWave = 5;
    [SerializeField] private float _spawnRate = 0.5f;
    [SerializeField] private float _waveRate = 2;
    [SerializeField] private float _returnTime = 15f;
    [Header("Count")]
    [SerializeField] private int _asteroidsInWaveMin = 10;
    [SerializeField] private int _asteroidsInWaveMax = 50;
    [Header("Boundaries")]
    [SerializeField] private float _spawnHeight = 12;
    [SerializeField] private Boundary _spawnBoundary;

    [SerializeField] private Enemy _enemyPrefab;
    private ObjectPool _enemyPool;

    public void Start()
    {
        _enemyPool = new ObjectPool(_enemyPrefab, 50);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_pauseBeforeFirstWave);

        while (true)
        {
            int countAsteroids = Random.Range(_asteroidsInWaveMin, _asteroidsInWaveMin);

            for (int i = 0; i < countAsteroids; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(_spawnBoundary.xMin, _spawnBoundary.xMax), 0, _spawnHeight);
                //Quaternion spawnRotation = Quaternion.identity;
                
                StartCoroutine(ReturnBulletWithTime(_enemyPool.GetObject(spawnPosition), _returnTime));

                yield return new WaitForSeconds(_spawnRate);
            }

            yield return new WaitForSeconds(_waveRate);
        }
    }

    private IEnumerator ReturnBulletWithTime(PoolableObject objectToReturn, float timeForReturn)
    {
        yield return new WaitForSeconds(20);

        _enemyPool.ReturnObjectToPool(objectToReturn);
    }
}

