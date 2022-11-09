using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
    [SerializeField] private GameObject _currentPanel;

    public void Start()
    {
        _playButton.onClick.AddListener(() => {
            SceneManager.LoadScene(_sceneForStartGame);
        });

        _recordsButton.onClick.AddListener(() => {
            _recordsList.gameObject.SetActive(true);
            _currentPanel = _recordsList;
            _backButton.gameObject.SetActive(true);
        });

        _quitButton.onClick.AddListener(() => { 
            Application.Quit();
        });

        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        _currentPanel.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

}
