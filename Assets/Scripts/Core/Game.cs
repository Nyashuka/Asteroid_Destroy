using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private void Start()
    {
        _player.DeathEvent += EndTheGame;
        _player.KilledEnemy += AddScore;
    }

    private void EndTheGame()
    { 
        // some logic
    }

    private void AddScore(Enemy killedEnemy)
    {
        _score.AddScore(killedEnemy);
    }
}

