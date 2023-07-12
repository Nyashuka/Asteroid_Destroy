using System.Collections;
using System.Threading.Tasks;
using Services.EventBusModule;
using Services.EventBusService;
using Services.ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class MainMenuUI : UIElement
    {
        [SerializeField] private Text maxScoreText;
        [SerializeField] private Button playButton;
        [SerializeField] private Button recordsButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingsButton;

        [SerializeField] private EventBus _eventBus;
        public override void Show()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }
            /*
            maxScoreText.text = ServiceLocator.Instance.GetService<PlayerDataManager>()
                .CurrentPlayer.MaxScore
                .ToString();
                */

        public override void Initialize()
        {
            _eventBus = ServiceLocator.Instance.GetService<EventBus>();
            
            playButton.onClick.AddListener(RaisePlayButtonClicked);
        }
        

        private async void RaisePlayButtonClicked()
        {
            _eventBus
                .Raise(EventBusDefinitions.PlayButtonClicked, new EmptyEventBusArgs());
            await _eventBus
                .RaiseAsync(EventBusDefinitions.PlayButtonClicked, new EmptyEventBusArgs());

        }
    }
}