using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesLoader
    {
        private const string GameScene = "Game";
        private const string MainMenuScene = "MainMenu";

        public Task LoadMainMenu() 
        {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        
            return Task.CompletedTask;
        }

        public Task LoadGame()
        {
            SceneManager.LoadScene(GameScene, LoadSceneMode.Single);

            return Task.CompletedTask;
        }
    }
}

