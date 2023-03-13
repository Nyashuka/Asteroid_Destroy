using Assets.Scripts.Core.Game;
using Assets.Scripts.Core.Player.Bonuses;
using Assets.Scripts.Core.Utils;
using Assets.Scripts.DataStructures;
using System.Linq;
using UnityEngine;

public class BonusSpawner
{
    private GameObject[] _bonuses;
    private int[] _chanceTable;
    private readonly int _dropChance = 10;
    private EnemiesSpawner _enemyFactory;
    private Transform _parentForSpawn;

    private int _totalChance;

    public BonusSpawner(GameObject[] bonuses, int[] chanceTable, EnemiesSpawner enemyFactory)
    {
        _parentForSpawn = new GameObject("parent_for_bonuses").transform;

        _bonuses = bonuses;
        _chanceTable = chanceTable;
        _enemyFactory = enemyFactory;

        _enemyFactory.EnemyDeath += Spawn;
        _totalChance = _chanceTable.Sum();

        ScreenBoundary.Instance.LeftWorld += DestroyBuff;
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
                MonoBehaviour.Instantiate(_bonuses[i], enemy.transform.position, Quaternion.identity, _parentForSpawn);
                
                return;
            }
            else
            {
                dropedChance -= _chanceTable[i];
            }
        }
    }

    private void DestroyBuff(IDestroyable destroyable)
    {
        if(destroyable is BuffContainer container)
            MonoBehaviour.Destroy(container.gameObject);
    }
}
