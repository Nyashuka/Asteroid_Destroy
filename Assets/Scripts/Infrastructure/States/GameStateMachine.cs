using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services.ServiceLocatorSystem;

namespace Infrastructure.States
{
    public class GameStateMachine : IService
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _currentState;

        public GameStateMachine()
        {
            _states.Add(typeof(BootState), new BootState());
            _states.Add(typeof(LoadMainMenuState), new LoadMainMenuState());
            _states.Add(typeof(GameState), new GameState());
        }

        public async Task Enter<T>() where T : IState
        {
            _currentState?.Exit();

            IState nextState = _states[typeof(T)];
            _currentState = nextState;
            
            await nextState.Enter();
        }
    }
}
