using Assets.Scripts.Services.Pause;
using UnityEngine;

public class ServicesProvider : MonoBehaviour
{
    public JsonSaveSystem SaveSystem { get; private set; }
    public PauseManager PauseManager { get; private set; }
    public PlayerDataManager PlayerDataManager => _playerDataManager;

    [SerializeField] private PlayerDataManager _playerDataManager;

    public static ServicesProvider Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Initialize();
        DontDestroyOnLoad(this);
    }

    private void Initialize()
    {
        SaveSystem = new JsonSaveSystem();

        PauseManager = new PauseManager();
        InitializePauseManger();
    }

    private void InitializePauseManger()
    {
        PauseManager.Register(new GamePauseBehaviour());
    }
}
