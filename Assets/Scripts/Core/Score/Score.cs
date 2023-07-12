using System;
using Core.Enemies;

namespace Core.Score
{
    public class Score
    {
        private UnitySerializedDictionary<EnemyTypes, int> _scoresAmountToAdd =
            new UnitySerializedDictionary<EnemyTypes, int>()
            {
                { EnemyTypes.Asteroid , 100 },
            };

        private int _currentScore = 0;
        public int Value => _currentScore; 
   
        public event Action<int> ScoreChangedEvent;

        public void AddScore(Enemy killedEnemy)
        {
            if(_scoresAmountToAdd.TryGetValue(killedEnemy.EnemyType, out var score))
            {
                _currentScore += score;
                ScoreChangedEvent?.Invoke(_currentScore);
            }          
        }
    }
}

