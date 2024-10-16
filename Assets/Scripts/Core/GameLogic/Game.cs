﻿using Assets.Scripts.Core.PlayersComponents;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using Core.Factory;
using Infrastructure.States;
using Services;
using UnityEngine;

namespace Assets.Scripts.Core.GameLogic
{
    public class Game : MonoBehaviour
    {
        private Player _player;
        private PlayerDataManager _playersDataStorage;

        private EnemiesSpawner _enemySpawner;
        
        private Score _score;
        private bool _isGameOver;

        private PauseManager _pauseManager;

        public event Action GameOverEvent;

        private async void Start()
        {
            await ServiceLocator.Instance.GetService<StateMachine>().Enter<GameState>();

            _pauseManager = ServiceLocator.Instance.GetService<PauseManager>();

            _enemySpawner = new EnemiesSpawner(ServiceLocator.Instance.GetService<EnemyFactory>());
            _enemySpawner.EnemyDeath += AddScore;
            _enemySpawner.StartSpawn();

            _score = new Score();

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

        private void OnDestroy()
        {
            _enemySpawner.Destroy();
        }

        public void UpdatePlayerData()
        {
            _playersDataStorage.UpdatePlayerData(_score.Value);
        }
    }
}


