using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Score _score;
    private PlayersDataStorage _playersDataStorage;
    private PlayerData _currentPlayer;

    private void Start()
    {
        _player.DeathEvent += EndTheGame;
        _enemyFactory.EnemyDeath += AddScore;
    }

    private void EndTheGame()
    { 
        
    }

    private void AddScore(Enemy killedEnemy)
    {
        _score.AddScore(killedEnemy);
    }
}

