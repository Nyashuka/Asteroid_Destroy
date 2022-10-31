using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMenuSubscriber : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private string _sceneForStartGame;

    public void Start()
    {
        _playButton.onClick.AddListener(() => {
            SceneManager.LoadScene(_sceneForStartGame);
        });
    }
}
