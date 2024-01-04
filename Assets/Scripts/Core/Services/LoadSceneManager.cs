using System.Threading.Tasks;
using Better.Extensions.Runtime.AsyncExtension;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesLoader
    {
        private const string GameScene = "Game";

        public async Task LoadGame(LoadSceneMode mode = LoadSceneMode.Single) 
        {
            await SceneManager.LoadSceneAsync(GameScene, mode);
            SetActiveScene(GameScene);
        }

        private void SetActiveScene(string sceneName)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}

