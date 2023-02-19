using Assets.Scripts.Core.Game;
using Assets.Scripts.Core.Player;
using Assets.Scripts.Core.Utils;
using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PoolableObject _enemyPrefab;
    [SerializeField] private ScoreView _scoreView;

    private EnemiesSpawner _enemiesSpawner;
    private BonusSpawner _bonusSpawner;
    private Score _score;
    
    private bool _isGameOver;

    public PlayerDataManager PlayersDataStorage => ServicesProvider.Instance.PlayerDataManager;
    public Score Score => _score;

    public event Action GameOverEvent;

    private void Start()
    {
        ServicesProvider.Instance.PauseManager.SetPaused(false);

        _enemiesSpawner = new EnemiesSpawner(_enemyPrefab);
        _bonusSpawner = new BonusSpawner();

        _player.DeathEvent += EndTheGame;

        _enemiesSpawner.EnemyDeath += AddScore;

        InitializeScore();
    }

    private void InitializeScore()
    {
        _score = new Score();
        _scoreView.Init(_score);
    }

    private void EndTheGame()
    {
        _isGameOver = true;
        GameOverEvent?.Invoke();
        Destroy(_player.gameObject);
        PlayersDataStorage.UpdatePlayerData(_score.Value);
    }

    private void OnDestroy()
    {
        _enemiesSpawner.Destroy();
    }

    private void AddScore(Enemy killedEnemy)
    {
        if (_isGameOver)
            return;

        _score.AddScore(killedEnemy);
    }
}

