using UnityEngine;

public class Score : MonoBehaviour
{
    private int _currentScore = 0;
    private int _lastScore;
    private int _maxScore;

    private const int AMOUNT_SCORE_TO_ADD = 50;

    public void AddScore(IEnemy killedEnemy)
    {
        if (killedEnemy is Asteroid)
            _currentScore += AMOUNT_SCORE_TO_ADD;
    }
}

