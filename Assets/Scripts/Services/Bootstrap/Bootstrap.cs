
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Services.ServiceLocatorSystem;
using UnityEngine;

namespace Assets.Scripts.Services.Bootstrap
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
