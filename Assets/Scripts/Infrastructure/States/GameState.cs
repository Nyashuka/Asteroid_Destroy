using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Factory;
using Services;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameState : IState
    {
        private StateMachine _stateMachine;

        public GameState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private async Task Init()
        {
            try
            {
                PrefabsContainer dataContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

                string enemyPrefabGUID = dataContainer.GameData.EnemyPrefabAssetReference.AssetGUID;
                GameObject enemyPrefab = await AddressablesLoader.LoadAsync<GameObject>(enemyPrefabGUID);

                string playerPrefabGUID = dataContainer.GameData.PlayerPrefabAssetReference.AssetGUID;
                GameObject playerPrefab = await AddressablesLoader.LoadAsync<GameObject>(playerPrefabGUID);

                PauseManager pauseManager = new PauseManager();
                ServiceLocator.Instance.Register(pauseManager);

                PlayerFactory playerFactory = new PlayerFactory(playerPrefab);
                ServiceLocator.Instance.Register(playerFactory);

                BonusFactory bonusSpawner = new BonusFactory();
                ServiceLocator.Instance.Register(bonusSpawner);

                EnemyFactory enemyFactory = new EnemyFactory(enemyPrefab.GetComponent<PoolableObject>());
                ServiceLocator.Instance.Register(enemyFactory);
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }


        public async Task Enter()
        {           
            await Init();           
        }


        public void Exit()
        {
            
        }
    }
}
