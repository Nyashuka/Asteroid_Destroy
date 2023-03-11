using Assets.Scripts.Core.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Image _menuPanel;
    [SerializeField] private GameObject _saveRecordPanel;
    //[SerializeField] private Image _menuPanel;
    [SerializeField] private Text _gameOverText;
    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _saveRecordButton;
    [SerializeField] private Button _saveButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _restartButton.onClick.AddListener(OnRestartGameButtonClicked);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
        _saveRecordButton.onClick.AddListener(OnToSaveRecordButtonClicked);
        _saveButton.onClick.AddListener(OnSaveButtonClicked);

        _game.GameOverEvent += OnGameOver;
    }

    private void OnSaveButtonClicked()
    {
        _saveRecordPanel.SetActive(false);
        _restartButton.gameObject.SetActive(true);
        _saveRecordButton.gameObject.SetActive(true);
        _exitToMenuButton.gameObject.SetActive(true);
    }

    private void OnToSaveRecordButtonClicked()
    {
        _saveRecordPanel.SetActive(true);
        _restartButton.gameObject.SetActive(false);
        _saveRecordButton.gameObject.SetActive(false);
        _exitToMenuButton.gameObject.SetActive(false);
    }

    private void OnExitToMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
        _game.UpdatePlayerData();
    }

    private void OnRestartGameButtonClicked()
    {
        _game.SetPaused(false);
        SceneManager.LoadScene("Game");
    }

    private void OnPauseButtonClicked()
    {
        _game.SetPaused(true);
        ShowGeneral();
        _resumeButton.gameObject.SetActive(true);
    }

    private void OnResumeButtonClicked()
    {
        _game.SetPaused(false);
        _resumeButton.gameObject.SetActive(false);
        HideGeneral();
    }

    private void OnGameOver()
    {
        ShowGeneral();
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        _saveRecordButton.gameObject.SetActive(true);
    }

    private void ShowGeneral()
    {
        _menuPanel.gameObject.SetActive(true);
        _exitToMenuButton.gameObject.SetActive(true);
    }

    private void HideGeneral()
    {
        _menuPanel.gameObject.SetActive(false);
        _exitToMenuButton.gameObject.SetActive(false);
    }
}
