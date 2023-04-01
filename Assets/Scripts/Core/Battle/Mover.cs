using Assets.Scripts.Services.ServiceLocatorSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IPauseHandler
{
    [SerializeField] private float _speed;
    private bool IsPaused = false;

    public void Start()
    {
        ServiceLocator.Instance.GetService<PauseManager>().Register(this);
    }

    private void Update()
    {
        if (IsPaused)
            return;

        transform.Translate(0,0, _speed * Time.deltaTime);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;
    }
}
