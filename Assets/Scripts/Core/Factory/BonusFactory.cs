using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusFactory : MonoBehaviour
{
    [SerializeField] private int[] _chanceTable;
    [SerializeField] private int _dropChance;

    [SerializeField] private string[] _bonuses;

    [SerializeField] private EnemyFactory _enemyFactory;

    int _totalChance;
    
    public void Start()
    {
        _enemyFactory.EnemyDeath += Spawn;
        _totalChance = _chanceTable.Sum();
    }

    private void Spawn(Enemy enemy)
    {
        int dropedChance = Random.Range(0, _totalChance);

        for (int i = 0; i < _chanceTable.Length; i++)
        {
            if (dropedChance <= _chanceTable[i])
            {
                Debug.Log(_bonuses[i]);
                return;
            }
            else
            {
                dropedChance -= _chanceTable[i];
            }
        }
    }

    private void SpawnBonus(IBattleBonus battleBonus)
    {
        // spawn obj
    }
}
