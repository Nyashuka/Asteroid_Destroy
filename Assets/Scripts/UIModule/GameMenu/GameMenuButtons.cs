using Core;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameMenu
{
    public class GameMenuButtons : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameMenu gameMenu;
        [SerializeField] private Game game;

        [Header("Buttons")]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button openSaveRecordWindowButton;
        [SerializeField] private Button saveRecordButton;
    
        private ScenesLoader _loadSceneManager;

        private void Start()
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            openSaveRecordWindowButton.onClick.AddListener(OnOpenSaveRecordButtonClicked);
            saveRecordButton.onClick.AddListener(OnSaveRecordButtonClicked);

            game.GameOverEvent += OnGameOldOver;

            _loadSceneManager = new ScenesLoader();
        }

        private void OnSaveRecordButtonClicked()
        {
            gameMenu.CloseSaveRecordWindow();
        }

        private void OnOpenSaveRecordButtonClicked()
        {
            gameMenu.OpenSaveRecordWindow();
        }

        private void OnPauseButtonClicked()
        {
            game.SetPaused(true);
            gameMenu.ShowPauseWindow();
        }

        private void OnResumeButtonClicked()
        {
            game.SetPaused(false);
            gameMenu.ClosePauseWindow();
        }

        private void OnGameOldOver()
        {
            gameMenu.ShowGameOverWindow();
        }
    }
}
