using System;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _currentScore = 0;
    private int _lastScore;
    private int _maxScore;

    private const int AMOUNT_SCORE_TO_ADD = 50;

    private Dictionary<Type, int> _scoresAmountToAdd = new Dictionary<Type, int>()
    {
        { typeof(Asteroid), 50 },
    };

    public void AddScore(Enemy killedEnemy)
    {
        if(_scoresAmountToAdd.TryGetValue(killedEnemy.GetType(), out var score))
            _currentScore += score;
    }
}

