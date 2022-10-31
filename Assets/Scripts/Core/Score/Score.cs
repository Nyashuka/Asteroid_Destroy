using System;
using System.Collections.Generic;
using UnityEngine;

public class MyDictionary : UnitySerializedDictionary<Enemy, int>
{
  
}

public class Score : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int _currentScore = 0;
    public int Value => _currentScore;

    [SerializeField] private UnitySerializedDictionary<EnemyTypes, int> _scoresAmountToAdd = 
                         new UnitySerializedDictionary<EnemyTypes, int>();
  
    public void AddScore(Enemy killedEnemy)
    {
        if(_scoresAmountToAdd.TryGetValue(killedEnemy.EnemyType, out var score))
        {
            _currentScore += score;
            ScoreChanged?.Invoke(_currentScore);
        }
            
    }
}

