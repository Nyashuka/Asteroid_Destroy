using System;
using Assets.Scripts.Core.PlayersComponents;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Enemies;
using Core.Factory;
using Infrastructure.States;
using SaveSystem;
using Services;
using Services.Pause;
using Services.ServiceLocatorSystem;
using UnityEngine;

namespace Core.GameLogic
{
    public class GameOld : MonoBehaviour
    {
        private Player _player;
        private PlayerDataManager _playersDataStorage;

        private EnemiesSpawner _enemySpawner;
        
        private global::Core.Score.Score _score;
        private bool _isGameOver;

        private PauseManager _pauseManager;

        public event Action GameOverEvent;

        private async void Start()
        {
            await ServiceLocator.Instance.GetService<GameStateMachine>().Enter<GameState>();

            _pauseManager = ServiceLocator.Instance.GetService<PauseManager>();

            _enemySpawner = new EnemiesSpawner(ServiceLocator.Instance.GetService<EnemyFactory>());
            _enemySpawner.StartSpawn();

            _score = new Score.Score();

            _player = ServiceLocator.Instance.GetService<PlayerFactory>().Create();
            _player.DeathEvent += EndTheGame;

            _playersDataStorage = ServiceLocator.Instance.GetService<PlayerDataManager>();
            ServiceLocator.Instance.GetService<PlayerViewContainer>().ScoreView.Init(_score);
        }
        
        public void SetPaused(bool isPause)
        {
            _pauseManager.SetPaused(isPause);
        }

        private void EndTheGame()
        {
            _isGameOver = true;
            GameOverEvent?.Invoke();
            Destroy(_player.gameObject);
            _playersDataStorage.UpdatePlayerData(_score.Value);
        }   

        private void AddScore(Enemy killedEnemy)
        {
            if (_isGameOver)
                return;

            _score.AddScore(killedEnemy);
        }

        public void SaveRecord(string text)
        {
            _playersDataStorage.SaveSomePlayer(text, _score.Value);
        }

        private void OnDisable()
        {
            _enemySpawner.Destroy();
        }

        public void UpdatePlayerData()
        {
            _playersDataStorage.UpdatePlayerData(_score.Value);
        }
    }
}


