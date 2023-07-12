using System;
using System.Threading.Tasks;
using Core.Enemies;
using Core.Factory;
using Core.Score;
using Infrastructure.States;
using SaveSystem;
using Services.EventBusModule;
using Services.EventBusService;
using Services.Pause;
using Services.ServiceLocatorSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _gameStateMachine;
        private EventBus _eventBus;
        private PauseManager _pauseManager;
        private EnemiesSpawner _enemySpawner;
        private Score _score;
        private PlayerFactory _playerFactory;
        private PlayerDataManager _playersDataStorage;
        private bool _isGameOver;
        
        public event Action GameOverEvent;

        public Game()
        {
            _gameStateMachine = new GameStateMachine();
        }

        public async Task Boot()
        {
            await _gameStateMachine.Enter<BootState>();
            await _gameStateMachine.Enter<LoadMainMenuState>();
            
            RegisterEventBus();
        }

        private void GetServices()
        {
            
            _playerFactory = ServiceLocator.Instance.GetService<PlayerFactory>();
            _playersDataStorage = ServiceLocator.Instance.GetService<PlayerDataManager>();
            _pauseManager = ServiceLocator.Instance.GetService<PauseManager>();
        }

        private void InitEnemySpawner()
        {
            _enemySpawner = new EnemiesSpawner(ServiceLocator.Instance.GetService<EnemyFactory>());
            _enemySpawner.StartSpawn();
        }

        private async Task OnPlayButtonClicked(EventBusArgs args)
        {
            await Start();
        }

        private async Task Start()
        {
            await _gameStateMachine.Enter<GameState>();
            
            GetServices();
            InitEnemySpawner();

            _score = new Score();
            
            var player = _playerFactory.Create();
            player.DeathEvent += EndTheGame;
   
            //ServiceLocator.Instance.GetService<PlayerViewContainer>().ScoreView.Init(_score);
        }

        private void RegisterEventBus()
        {
            _eventBus = ServiceLocator.Instance.GetService<EventBus>();
            _eventBus.Subscribe(EventBusDefinitions.PlayButtonClicked, OnPlayButtonClicked);
        }

        private void EndTheGame()
        {
            _isGameOver = true;
            GameOverEvent?.Invoke();
            Object.Destroy(_playerFactory.Create().gameObject);
            _playersDataStorage.UpdatePlayerData(_score.Value);
        }

        private void AddScore(Enemy killedEnemy)
        {
            if (_isGameOver)
                return;

            _score.AddScore(killedEnemy);
        }
    }
}