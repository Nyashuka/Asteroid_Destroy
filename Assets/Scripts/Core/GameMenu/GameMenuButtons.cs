using Assets.Scripts.Core.GameMenu;
using Core.GameLogic;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuButtons : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameOld gameOld;
    [SerializeField] private GameMenu _gameMenu;

    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _openSaveRecordWindowButton;
    [SerializeField] private Button _saveRecordButton;
    
    private ScenesLoader _loadSceneManager;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _restartButton.onClick.AddListener(OnRestartGameButtonClicked);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
        _openSaveRecordWindowButton.onClick.AddListener(OnOpenSaveRecordButtonClicked);
        _saveRecordButton.onClick.AddListener(OnSaveRecordButtonClicked);

        gameOld.GameOverEvent += OnGameOldOver;

        _loadSceneManager = new ScenesLoader();
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
        gameOld.UpdatePlayerData();
        _loadSceneManager.LoadMainMenu();  
    }

    private void OnRestartGameButtonClicked()
    {
        gameOld.SetPaused(false);
        _loadSceneManager.LoadGame();
    }

    private void OnPauseButtonClicked()
    {
        gameOld.SetPaused(true);
        _gameMenu.ShowPauseWindow();
    }

    private void OnResumeButtonClicked()
    {
        gameOld.SetPaused(false);
        _gameMenu.ClosePauseWindow();
    }

    private void OnGameOldOver()
    {
        _gameMenu.ShowGameOverWindow();
    }
}
