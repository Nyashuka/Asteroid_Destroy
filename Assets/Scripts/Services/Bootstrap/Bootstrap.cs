using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Infrastructure.States;
using UnityEngine;

namespace Services.Bootstrap
{
    [DefaultExecutionOrder(100)]
    public class Bootstrap : MonoBehaviour
    {
        public async void Awake()
        {
            DontDestroyOnLoad(gameObject);

            var stateMachine = new StateMachine();
            ServiceLocator.Instance.Register(stateMachine);

            await stateMachine.Enter<BootState>();
        }
    }
}
