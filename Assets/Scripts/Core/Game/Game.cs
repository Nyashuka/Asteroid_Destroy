using System;
using UnityEngine;

namespace Assets.Scripts.Core.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private PoolableObject _enemyPrefab;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GameObject[] _bonusPrefabs;
        [SerializeField] private int[] _chanceTable;

        private EnemiesSpawner _enemiesSpawner;
        private BonusSpawner _bonusSpawner;
        private Score _score;

        private bool _isGameOver;

        public PlayerDataManager PlayersDataStorage => ServicesProvider.Instance.PlayerDataManager;

        public event Action GameOverEvent;

        private void Start()
        {
            SetPaused(false);

            _enemiesSpawner = new EnemiesSpawner(_enemyPrefab);
            _enemiesSpawner.StartSpawn();
            _bonusSpawner = new BonusSpawner(_bonusPrefabs, _chanceTable, _enemiesSpawner);

            _player.DeathEvent += EndTheGame;

            _enemiesSpawner.EnemyDeath += AddScore;

            InitializeScore();
        }

        private void InitializeScore()
        {
            _score = new Score();
            _scoreView.Init(_score);
        }

        public void SetPaused(bool isPause)
        {
            ServicesProvider.Instance.PauseManager.SetPaused(isPause);
        }

        private void EndTheGame()
        {
            _isGameOver = true;
            GameOverEvent?.Invoke();
            Destroy(_player.gameObject);
            PlayersDataStorage.UpdatePlayerData(_score.Value);
        }   

        private void AddScore(Enemy killedEnemy)
        {
            if (_isGameOver)
                return;

            _score.AddScore(killedEnemy);
        }

        public void SaveRecord(string text)
        {
            PlayersDataStorage.SaveSomePlayer(text, _score.Value);
        }

        private void OnDestroy()
        {
            _enemiesSpawner.Destroy();
        }

        public void UpdatePlayerData()
        {
            PlayersDataStorage.UpdatePlayerData(_score.Value);
        }
    }
}


