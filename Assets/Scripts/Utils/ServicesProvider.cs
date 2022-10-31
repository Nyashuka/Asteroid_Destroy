using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesProvider : MonoBehaviour
{
    public JsonSaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = new JsonSaveSystem();
    }
}
