using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusFactory : MonoBehaviour
{
    [SerializeField] private int[] _chanceTable;
    [SerializeField] private int _dropChance;

    [SerializeField] private IBattleBonus[] _bonuses;

    [SerializeField] private EnemyFactory _enemyFactory;
    
    public void Start()
    {
        _enemyFactory.EnemyDeath += Spawn;
    }

    private void Spawn(Enemy enemy)
    {
        int totalChance = _chanceTable.Sum();

        int dropedChance = Random.Range(0, totalChance);

        for (int i = 0; i < _chanceTable.Length; i++)
        {
            if(dropedChance <= 0)
                SpawnBonus(_bonuses[i]);

            dropedChance -= _chanceTable[i];
        }
    }

    private void SpawnBonus(IBattleBonus battleBonus)
    {
        // spawn obj
    }
}
