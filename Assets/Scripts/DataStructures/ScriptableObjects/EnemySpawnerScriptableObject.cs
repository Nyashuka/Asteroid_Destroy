
using UnityEngine;

namespace Assets.Scripts.DataStructures.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class EnemySpawnerScriptableObject : ScriptableObject
    {
        [SerializeField] private Transform _parentForPoolObjects;
        [Header("Timings")]
        [SerializeField] private float _pauseBeforeFirstWave = 5;
        [SerializeField] private float _spawnRate = 0.5f;
        [SerializeField] private float _waveRate = 2;
        [Header("Count")]
        [SerializeField] private int _asteroidsInWaveMin = 10;
        [SerializeField] private int _asteroidsInWaveMax = 50;
        [Header("Boundaries")]
        [SerializeField] private float _spawnHeight = 12;
        [SerializeField] private PoolableObject _enemyPrefab;

        public Transform ParentForPoolObjects => _parentForPoolObjects;
        public float PauseBeforeFirstWave => _pauseBeforeFirstWave;
        public float SpawnRate => _spawnRate;
        public float WaveRate  => _waveRate;
        public int AsteroidsInWaveMin  => _asteroidsInWaveMin;
        public int AsteroidsInWaveMax => _asteroidsInWaveMax;
        public float SpawnHeight => _spawnHeight; 
        public PoolableObject EnemyPrefab => _enemyPrefab;
    }
}
