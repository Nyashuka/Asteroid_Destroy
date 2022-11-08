using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesProvider : MonoBehaviour
{
    public JsonSaveSystem SaveSystem { get; private set; }
    public PauseManager PauseManager { get; private set; }

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
    }
}
