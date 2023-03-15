using Assets.Scripts.Core.GameLogic;
using Assets.Scripts.Core.GameMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuButtons : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Game _game;
    [SerializeField] private GameMenu _gameMenu;

    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _openSaveRecordWindowButton;
    [SerializeField] private Button _saveRecordButton;
    
    private LoadSceneManager _loadSceneManager;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _restartButton.onClick.AddListener(OnRestartGameButtonClicked);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
        _openSaveRecordWindowButton.onClick.AddListener(OnOpenSaveRecordButtonClicked);
        _saveRecordButton.onClick.AddListener(OnSaveRecordButtonClicked);

        _game.GameOverEvent += OnGameOver;

        _loadSceneManager = new LoadSceneManager();
    }

    private void OnSaveRecordButtonClicked()
    {
        _gameMenu.CloseSaveRecordWindow();
    }

    private void OnOpenSaveRecordButtonClicked()
    {
       _gameMenu.OpenSaveRecordWindow();
    }

    private void OnExitToMenuButtonClicked()
    {
        _game.UpdatePlayerData();
        _loadSceneManager.LoadMainMenu();  
    }

    private void OnRestartGameButtonClicked()
    {
        _game.SetPaused(false);
        _loadSceneManager.LoadGame();
    }

    private void OnPauseButtonClicked()
    {
        _game.SetPaused(true);
        _gameMenu.ShowPauseWindow();
    }

    private void OnResumeButtonClicked()
    {
        _game.SetPaused(false);
        _gameMenu.ClosePauseWindow();
    }

    private void OnGameOver()
    {
        _gameMenu.ShowGameOverWindow();
    }
}
