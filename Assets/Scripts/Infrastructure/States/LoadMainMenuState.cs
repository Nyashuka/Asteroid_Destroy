using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.States;
using Core.Services.ServiceLocatorSystem;
using Services;
using Services.EventBusModule;
using Services.EventBusService;
using UIModule;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadMainMenuState : IState
    {
        public async Task Enter()
        {
            InitializeMainMenu();
        }
        
        private void InitializeMainMenu()
        {
            PrefabsContainer prefabsContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

            UIController uiController = Object.Instantiate(prefabsContainer.UIData.UIDocument);
            EventBus eventBus = ServiceLocator.Instance.GetService<EventBus>();
            ServiceLocator.Instance.Register(uiController);
            uiController.Initialize(eventBus);
            
            eventBus.Raise(EventBusDefinitions.MainMenuLoaded, new EmptyEventBusArgs());
        }

        public void Exit()
        {
            
        }
    }
}