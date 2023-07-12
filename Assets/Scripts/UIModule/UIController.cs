using System.Collections.Generic;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services.EventBusModule;
using Services.EventBusService;
using Services.ServiceLocatorSystem;
using UnityEngine;

namespace UIModule
{
    public class UIController : MonoBehaviour, IService
    {
        [SerializeField] private MainMenuUI mainMenu;
        [SerializeField] private GameEndMenu gameEndMenu;
        [SerializeField] private PlayerHUD playerHUD;

        private UIElement _currentUIElement;
        private Stack<UIElement> _uiElementsHistory;

        public void Initialize(EventBus eventBus)
        {
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
            ChangeUIElement(mainMenu);
        }

        private void OpenGameEndMenu(EventBusArgs args)
        {
            ChangeUIElement(gameEndMenu);
        }

        private void ChangeUIElement(UIElement newUIElement)
        {
            if (_currentUIElement != null && _currentUIElement.GetType().Name != newUIElement.GetType().Name)
                Destroy(_currentUIElement.gameObject);
            
            _currentUIElement = Instantiate(newUIElement, transform);

            _currentUIElement.Initialize();
            _currentUIElement.Show();
        }
    }
}