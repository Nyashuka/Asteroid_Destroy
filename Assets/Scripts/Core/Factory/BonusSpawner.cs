using System.Linq;
using Assets.Scripts.Services;
using Core.Enemies;
using Core.PlayerComponents.Bonuses;
using Core.Services.ServiceLocatorSystem;
using Services;
using UnityEngine;
using Utils;

namespace Core.Factory
{
    public class BonusFactory : IService
    {
        private BonusData[] _bonusData;
        private readonly int _dropChance = 10;
        private readonly Transform _parentForSpawn;

        private int _totalChance;

        public BonusFactory()
        {
            InitBonusesPrefabsAndChanceTable();

            _parentForSpawn = new GameObject("parent_for_bonuses").transform;   
        }

        private void InitBonusesPrefabsAndChanceTable()
        {
            PrefabsContainer prefabsContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

            _bonusData = new BonusData[prefabsContainer.GameData.Bonuses.Length];
            int i = 0;

            foreach (var bonusData in prefabsContainer.GameData.Bonuses)
            {
                BuffContainer bonus = bonusData.Prefab;

                _bonusData[i] = new BonusData(bonus, bonusData.DropChance);
                i++;
            }

            _totalChance = _bonusData.Select(x => x.DropChance).Sum();

            ServiceLocator.Instance.GetService<EnemyFactory>().EnemyDeath += Create;
            ServiceLocator.Instance.GetService<ScreenBoundary>().LeftWorld += DestroyBuff;
        }

        private void Create(Enemy enemy)
        {
            if (Random.Range(0, 100) > _dropChance)
                return;

            int dropChance = Random.Range(0, _totalChance);

            for (int i = 0; i < _bonusData.Length; i++)
            {
                if (dropChance <= _bonusData[i].DropChance)
                {
                    Object.Instantiate(_bonusData[i].Prefab, enemy.transform.position, Quaternion.identity, _parentForSpawn);

                    return;
                }

                dropChance -= _bonusData[i].DropChance;
            }
        }

        private void DestroyBuff(IDestroyable destroyable)
        {
            if (destroyable is BuffContainer container)
                Object.Destroy(container.gameObject);
        }
    }
}
