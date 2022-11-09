using UnityEngine;
using UnityEngine.SceneManagement;

public static class PerformBootstrap
{
    private const string _sceneName = "Bootstrap";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var candidate = SceneManager.GetSceneAt(i);

            if (candidate.name == _sceneName)
                return;
        }

        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }
}