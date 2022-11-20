using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonsSubscriber : MonoBehaviour
{
    [SerializeField] private string _sceneForStartGame;
    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _recordsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _backButton;
    [Header("Panels")]
    [SerializeField] private GameObject _recordsList;
    private GameObject _currentPanel;

    public void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);

        _recordsButton.onClick.AddListener(OnRecordButtonClicked);

        _quitButton.onClick.AddListener(OnQuitButtonClicked);

        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(_sceneForStartGame);
    }

    private void OnRecordButtonClicked()
    {
        _recordsList.gameObject.SetActive(true);
        _currentPanel = _recordsList;
        _backButton.gameObject.SetActive(true);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    private void OnBackButtonClicked()
    {
        _currentPanel.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

}
