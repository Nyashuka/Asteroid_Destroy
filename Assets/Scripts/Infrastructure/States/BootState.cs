using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services;
using Services.EventBusService;

namespace Infrastructure.States
{
    public class BootState : IState
    {
        private GameStateMachine _gameStateMachine;

        public BootState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async Task Enter()
        {
            RegisterServices();

            ScenesLoader scenesLoader = new ScenesLoader();

            await scenesLoader.LoadGame();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(new PlayerDataManager(new JsonSaveSystem()));
            ServiceLocator.Instance.Register(new EventBus());
        }

        public void Exit()
        {
            
        }
    }
}
