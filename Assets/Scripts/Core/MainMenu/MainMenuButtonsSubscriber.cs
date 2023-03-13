using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Core.MainMenu
{
    public class MainMenuButtonsSubscriber : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _recordsButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _backButton;
        [Header("Panels")]
        [SerializeField] private GameObject _recordsList;
        [SerializeField] private GameObject _mainMenuUIPanel;
        private GameObject _currentPanel;
        private GameObject _previousPanel;

        public void Start()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
            _recordsButton.onClick.AddListener(OnRecordButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            _mainMenu.StartGame();
        }
        private void OnQuitButtonClicked()
        {
            _mainMenu.QuitGame();
        }

        private void OnRecordButtonClicked()
        {
            _recordsList.gameObject.SetActive(true);
            _mainMenuUIPanel.SetActive(false);
            _backButton.gameObject.SetActive(true);

            _currentPanel = _recordsList;
            _previousPanel = _mainMenuUIPanel;
        }
  
        private void OnBackButtonClicked()
        {
            _currentPanel.SetActive(false);
            _backButton.gameObject.SetActive(false);
            _previousPanel.SetActive(true);
        }

    }

}
