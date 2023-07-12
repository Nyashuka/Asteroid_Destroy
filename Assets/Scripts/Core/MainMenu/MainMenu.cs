using SaveSystem;
using UnityEngine;

namespace Core.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private PlayerDataManager _playerDataManager;
        
        public void Awake()
        {
            _playerDataManager = new PlayerDataManager(new JsonSaveSystem());
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
