using Assets.Scripts.Core.Game;
using System.Linq;
using UnityEngine;

public class BonusSpawner
{
    private GameObject[] _bonuses;
    private int[] _chanceTable;
    private int _dropChance;
    private EnemiesSpawner _enemyFactory;

    private int _totalChance;
    
    public void Start()
    {
        _enemyFactory.EnemyDeath += Spawn;
        _totalChance = _chanceTable.Sum();
    }

    private void Spawn(Enemy enemy)
    {
        if (Random.Range(0, 100) > _dropChance)
            return;

        int dropedChance = Random.Range(0, _totalChance);

        for (int i = 0; i < _chanceTable.Length; i++)
        {
            if (dropedChance <= _chanceTable[i])
            {
                MonoBehaviour.Instantiate(_bonuses[i], enemy.transform.position, Quaternion.identity);
                return;
            }
            else
            {
                dropedChance -= _chanceTable[i];
            }
        }
    }
}
