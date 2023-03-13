
using UnityEngine.SceneManagement;

public class LoadSceneManager
{
    private const string GAME_SCENE = "Game";
    private const string MAIN_MENU_SCENE = "MainMenu";

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE, LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GAME_SCENE, LoadSceneMode.Single);
    }
}

