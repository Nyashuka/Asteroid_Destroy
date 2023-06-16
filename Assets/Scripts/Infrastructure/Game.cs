using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _gameStateMachine;

        public Game()
        {
            _gameStateMachine = new GameStateMachine();
        }

        public async Task Boot()
        {
            await _gameStateMachine.Enter<BootState>();
        }

        public async Task Start()
        {
            await _gameStateMachine.Enter<LoadMainMenuState>();
        }
    }
}