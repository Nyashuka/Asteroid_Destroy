using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.GameLogic
{
    public class EnemiesSpawner
    {
        private readonly float _pauseBeforeFirstWave = 5;
        private readonly float _spawnRate = 0.5f;
        private readonly float _waveRate = 2;

        private readonly int _asteroidsInWaveMin = 10;
        private readonly int _asteroidsInWaveMax = 50;

        private readonly float _spawnHeight = 12;

        private CancellationTokenSource _source;

        private readonly EnemyFactory _enemyFactory;
        public event Action<Enemy> EnemyDeath;

        public EnemiesSpawner(EnemyFactory enemyFactory)
        {
            Transform parentForPoolObjects = new GameObject("Transform_Parent_For_Enemies").transform;

            _enemyFactory = enemyFactory;
            _enemyFactory.EnemyDeath += AnounceEntityDeath;
            
            _source = new CancellationTokenSource();    
        }

        public void StartSpawn()
        {
            Start(_source.Token);
        }

        private async void Start(CancellationToken token)
        {
            try
            {
                await Task.Delay(Mathf.RoundToInt(_pauseBeforeFirstWave * 1000), token);

                while (!token.IsCancellationRequested)
                {
                    int countAsteroids = UnityEngine.Random.Range(_asteroidsInWaveMin, _asteroidsInWaveMax);

                    for (int i = 0; i < countAsteroids; i++)
                    {
                        _enemyFactory.Create(_spawnHeight);

                        await Task.Delay(Mathf.RoundToInt(_spawnRate * 1000), token);
                    }


                    await Task.Delay(Mathf.RoundToInt(_waveRate * 1000), token);
                }
            }
            catch (TaskCanceledException)
            {
                
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
           
        }

        public void Destroy()
        {
            _source.Cancel(true);
        }

        public void AnounceEntityDeath(Enemy enemy)
        {
            EnemyDeath?.Invoke(enemy);
        }
    }
}
