using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using SaveSystem;
using Services;
using Services.EventBusService;
using Services.ServiceLocatorSystem;

namespace Infrastructure.States
{
    public class BootState : IState
    {
        public async Task Enter()
        {
            ScenesLoader scenesLoader = new ScenesLoader();
            
            await scenesLoader.LoadGame();
            
            RegisterServices();
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
