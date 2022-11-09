using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Score _score;
    private PlayersDataManager _playersDataStorage;

    private void Start()
    {
        _player.DeathEvent += EndTheGame;
        _enemyFactory.EnemyDeath += AddScore;
    }

    private void EndTheGame()
    {
        Destroy(_player);

    }

    private void AddScore(Enemy killedEnemy)
    {
        _score.AddScore(killedEnemy);
    }
}

