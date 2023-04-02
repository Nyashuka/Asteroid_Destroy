using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.States;

namespace Assets.Scripts.Infrastructure.States
{
    public class StateMachine : IService
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _currentState;

        public StateMachine()
        {
            _states.Add(typeof(BootState), new BootState(this));
            _states.Add(typeof(GameState), new GameState(this));
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
