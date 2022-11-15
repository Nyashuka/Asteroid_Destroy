using Assets.Scripts.Core.Player;
using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Score _score;
    private PlayersDataManager _playersDataStorage;

    private bool _isGameOver;

    public event Action GameOverEvent;

    private void Start()
    {
        _player.DeathEvent += EndTheGame;
        _enemyFactory.EnemyDeath += AddScore;
    }

    private void EndTheGame()
    {
        _isGameOver = true;
        GameOverEvent?.Invoke();
        Destroy(_player.gameObject);
    }

    private void AddScore(Enemy killedEnemy)
    {
        if (_isGameOver)
            return;

        _score.AddScore(killedEnemy);
    }
}

