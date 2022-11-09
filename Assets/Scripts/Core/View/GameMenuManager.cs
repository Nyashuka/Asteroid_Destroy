using Assets.Scripts.Core.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Image _menuPanel;
    //[SerializeField] private Image _menuPanel;
    [SerializeField] private Text _gameOverText;
    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _restartButton.onClick.AddListener(OnRestartGameButtonClicked);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);

        _game.GameOverEvent += OnGameOver;
    }

    private void OnExitToMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestartGameButtonClicked()
    {
        ServicesProvider.Instance.PauseManager.SetPaused(false);
        SceneManager.LoadScene("Game");
    }

    private void OnPauseButtonClicked()
    {
        ServicesProvider.Instance.PauseManager.SetPaused(true);
        ShowGeneral();
        _resumeButton.gameObject.SetActive(true);
    }

    private void OnResumeButtonClicked()
    {
        ServicesProvider.Instance.PauseManager.SetPaused(false);
        _resumeButton.gameObject.SetActive(false);
        HideGeneral();
    }

    private void OnGameOver()
    {
        ShowGeneral();
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
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
