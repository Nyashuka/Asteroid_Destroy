using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyDic : SerializableDictionary<Type, int>
{

}

public class Score : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int _currentScore = 0;

    [SerializeField]private MyDic _dic;

    [SerializeField] private SerializableDictionary<Type, int> _scoresAmountToAdd = new SerializableDictionary<Type, int>()
    {
        { typeof(Asteroid), 50 },

    };

    public void AddScore(Enemy killedEnemy)
    {
        if(_scoresAmountToAdd.TryGetValue(killedEnemy.GetType(), out var score))
        {
            _currentScore += score;
            ScoreChanged?.Invoke(_currentScore);
        }
            
    }
}

