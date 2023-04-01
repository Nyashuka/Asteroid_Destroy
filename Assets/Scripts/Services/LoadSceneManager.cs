
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ScenesLoader
{
    private const string GAME_SCENE = "Game";
    private const string MAIN_MENU_SCENE = "MainMenu";

    public Task LoadMainMenu() 
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE, LoadSceneMode.Single);
        
        return Task.CompletedTask;
    }

    public Task LoadGame()
    {
        SceneManager.LoadScene(GAME_SCENE, LoadSceneMode.Single);

        return Task.CompletedTask;
    }
}

