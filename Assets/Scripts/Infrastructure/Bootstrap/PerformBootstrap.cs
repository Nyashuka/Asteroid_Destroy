using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Bootstrap
{
    public static class PerformBootstrap
    {
        private const string SceneName = "Bootstrap";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var candidate = SceneManager.GetSceneAt(i);

                if (candidate.name == SceneName)
                    return;
            }

            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
    }
}