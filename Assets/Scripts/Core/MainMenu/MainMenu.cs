using System;
using UnityEngine;

namespace Assets.Scripts.Core.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private PlayerDataManager _playerDataManager;
        private ScenesLoader _loadSceneManager;

        public void Awake()
        {
            _playerDataManager = new PlayerDataManager(new JsonSaveSystem());
            _loadSceneManager = new ScenesLoader();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            _loadSceneManager.LoadGame();
        }
    }
}
