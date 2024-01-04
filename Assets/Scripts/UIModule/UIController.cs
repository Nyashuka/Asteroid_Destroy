using System.Collections.Generic;
using Core.Services.ServiceLocatorSystem;
using Services.EventBusModule;
using Services.EventBusService;
using UnityEngine;

namespace UIModule
{
    public class UIController : MonoBehaviour, IService
    {
        [SerializeField] private MainMenuUI mainMenu;
        [SerializeField] private GameEndMenu gameEndMenu;
        [SerializeField] private PlayerHUD playerHUD;

        private EventBus _eventBus;
        private UIElement _currentUIElement;
        private Stack<UIElement> _uiElementsHistory;

        public void Initialize(EventBus eventBus)
        {
            _eventBus = eventBus;
            
            RegisterServices(eventBus);
        }

        private void RegisterServices(EventBus eventBus)
        {
            eventBus.Subscribe(EventBusDefinitions.MainMenuLoaded, OpenMainMenu);
            eventBus.Subscribe(EventBusDefinitions.Lost, OpenGameEndMenu);
            eventBus.Subscribe(EventBusDefinitions.PlayButtonClicked, OpenPlayerHUD);
        }

        private void OpenPlayerHUD(EventBusArgs args)
        {
            ChangeUIElement(playerHUD);
        }

        private void OpenMainMenu(EventBusArgs args)
        {
            MainMenuUI mainMenuUI = ChangeUIElement(mainMenu);
            mainMenuUI.PlayButtonClicked += RaisePlayButtonClicked;
        }

        private void OpenGameEndMenu(EventBusArgs args)
        {
            ChangeUIElement(gameEndMenu);
        }
        
        private async void RaisePlayButtonClicked()
        {
            _eventBus
                .Raise(EventBusDefinitions.PlayButtonClicked, new EmptyEventBusArgs());
            await _eventBus
                .RaiseAsync(EventBusDefinitions.PlayButtonClicked, new EmptyEventBusArgs());
        }

        private T ChangeUIElement<T>(T newUIElement) where T : UIElement
        {
            if (_currentUIElement != null && _currentUIElement.GetType().Name != newUIElement.GetType().Name)
                Destroy(_currentUIElement.gameObject);
            
            T uiElement = Instantiate(newUIElement, transform);
            _currentUIElement = uiElement;

            _currentUIElement.Initialize();
            _currentUIElement.Show();

            return uiElement;
        }
    }
}