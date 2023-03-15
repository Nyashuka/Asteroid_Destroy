using Assets.Scripts.Services.Pause;
using UnityEngine;

public class ServicesProvider : MonoBehaviour
{
    public PauseManager PauseManager { get; private set; }
    public PlayerDataManager PlayerDataManager { get; private set; }

    public static ServicesProvider Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Initialize();
        DontDestroyOnLoad(this);
    }

    private void Initialize()
    {
        PlayerDataManager = new PlayerDataManager(new JsonSaveSystem());

        PauseManager = new PauseManager();
    }
}
