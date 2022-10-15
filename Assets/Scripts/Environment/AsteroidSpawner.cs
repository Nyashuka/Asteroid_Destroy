using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidPrefabs;
    [Header("Timings")]
    [SerializeField] private float _pauseBeforeFirstWave;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _waveRate;
    [SerializeField] private float _destroyAfter;
    [Header("Count")]
    [SerializeField] private int _asteroidsInWaveMin;
    [SerializeField] private int _asteroidsInWaveMax;
    [Header("Boundaries")]
    [SerializeField] private float _spawnHeight;
    [SerializeField] private Boundary _spawnBoundary;

    private void Start()
    {
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
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazard = _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)];

                Destroy(Instantiate(hazard, spawnPosition, spawnRotation), _destroyAfter);

                yield return new WaitForSeconds(_spawnRate);
            }

            yield return new WaitForSeconds(_waveRate);
        }
    }
}
