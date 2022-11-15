using Assets.Scripts.Core.Player;
using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Score _score;
    public PlayerDataManager PlayersDataStorage => ServicesProvider.Instance.PlayerDataManager;

    private bool _isGameOver;

    public event Action GameOverEvent;

    private void Start()
    {
        ServicesProvider.Instance.PauseManager.SetPaused(false);
        _player.DeathEvent += EndTheGame;
        _enemyFactory.EnemyDeath += AddScore;
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
}

