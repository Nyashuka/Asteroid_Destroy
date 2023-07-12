using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Factory;
using Services;
using Services.EventBusService;
using Services.Pause;
using Services.ServiceLocatorSystem;
using UnityEngine;
using Utils;

namespace Infrastructure.States
{
    public class GameState : IState
    {
        private Task Init()
        {
            try
            {
                PrefabsContainer prefabsContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

                PauseManager pauseManager = new PauseManager();
                ServiceLocator.Instance.Register(pauseManager);

                PlayerFactory playerFactory = new PlayerFactory(prefabsContainer.GameData.PlayerPrefab);
                ServiceLocator.Instance.Register(playerFactory);

                ScreenBoundary boundary = Object.Instantiate(prefabsContainer.GameData.ScreenBoundaryPrefab);
                ServiceLocator.Instance.Register(boundary);
                
                EnemyFactory enemyFactory = new EnemyFactory(prefabsContainer.GameData.EnemyPrefab, boundary, 
                    ServiceLocator.Instance.GetService<EventBus>());
                ServiceLocator.Instance.Register(enemyFactory);

                BonusFactory bonusSpawner = new BonusFactory();
                ServiceLocator.Instance.Register(bonusSpawner);
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }

            return Task.CompletedTask;
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
