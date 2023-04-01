using Assets.Scripts.Core.GameLogic;
using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Core.Utils;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BonusFactory : IService
{
    private BonusData[] _bonusDatas;
    private readonly int _dropChance = 10;
    private Transform _parentForSpawn;

    private int _totalChance;

    public BonusFactory()
    {
        Task task = new Task(InitBonusesPrefabsAndChanseTable);
        task.Start();  
        task.Wait();    

        _parentForSpawn = new GameObject("parent_for_bonuses").transform;   
    }

    private async void InitBonusesPrefabsAndChanseTable()
    {
        PrefabsContainer prefabsContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

        _bonusDatas = new BonusData[prefabsContainer.GameData.Bonuses.Count];
        int i = 0;

        foreach (var prefab in prefabsContainer.GameData.Bonuses)
        {
            GameObject bonus =
                (await AddressablesLoader.LoadAsync<GameObject>(prefab.Key.AssetGUID)).GetComponent<GameObject>();

            _bonusDatas[i] = new BonusData(bonus, prefab.Value);
            i++;
        }

        _totalChance = _bonusDatas.Select(x => x.dropChance).Sum();

        ServiceLocator.Instance.GetService<EnemyFactory>().EnemyDeath += Create;
        ServiceLocator.Instance.GetService<ScreenBoundary>().LeftWorld += DestroyBuff;
    }

    private void Create(Enemy enemy)
    {
        if (Random.Range(0, 100) > _dropChance)
            return;

        int dropedChance = Random.Range(0, _totalChance);

        for (int i = 0; i < _bonusDatas.Length; i++)
        {
            if (dropedChance <= _bonusDatas[i].dropChance)
            {
                MonoBehaviour.Instantiate(_bonusDatas[i].prefab, enemy.transform.position, Quaternion.identity, _parentForSpawn);

                return;
            }
            else
            {
                dropedChance -= _bonusDatas[i].dropChance;
            }
        }
    }

    private void DestroyBuff(IDestroyable destroyable)
    {
        if (destroyable is BuffContainer container)
            MonoBehaviour.Destroy(container.gameObject);
    }
}
