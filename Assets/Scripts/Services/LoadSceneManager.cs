using System.Threading.Tasks;
using Better.Extensions.Runtime.AsyncExtension;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesLoader
    {
        private const string GameScene = "Game";

        public async Task LoadGame() 
        {
            await SceneManager.LoadSceneAsync(GameScene, LoadSceneMode.Single);
        }
    }
}

