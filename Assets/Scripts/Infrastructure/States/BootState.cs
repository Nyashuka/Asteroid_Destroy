using Assets.Scripts.Services.ServiceLocatorSystem;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootState : IState
    {
        private StateMachine _stateMachine;

        public BootState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public async Task Enter()
        {
            ServiceLocator.Instance.Register(new PlayerDataManager(new JsonSaveSystem()));

            ScenesLoader scenesLoader = new ScenesLoader();

            await scenesLoader.LoadGame();
        }

        public void Exit()
        {
            
        }
    }
}
