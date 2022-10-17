using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private void Start()
    {
        _player.DeathEvent += EndTheGame;
        _player.KillEnemy += AddScore;
    }

    private void EndTheGame()
    { 
        // some logic
    }

    private void AddScore(IEnemy killedEnemy)
    {
        _score.AddScore(killedEnemy);
    }
}

