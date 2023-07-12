using Assets.Scripts.Services.ServiceLocatorSystem;
using System.Collections;
using System.Collections.Generic;
using Services.Pause;
using Services.ServiceLocatorSystem;
using UnityEngine;

public class AsteroidMove : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _tumble;

    private void Start()
    {
        ServiceLocator.Instance.GetService<PauseManager>().Register(this);

        PushAsteroid();
    }

    private void OnDisable()
    {
        ServiceLocator.Instance.GetService<PauseManager>().UnRegister(this);
    }

    public void SetPaused(bool isPaused)
    {
        if(isPaused)
            StopAsteroid();
        else
            PushAsteroid();
    }

    private void PushAsteroid()
    {
        _rigidbody.velocity = new Vector3(0, 0, Vector3.forward.z * _speed);
        _rigidbody.angularVelocity = Random.insideUnitSphere * _tumble;
    }

    private void StopAsteroid()
    {
        _rigidbody.velocity = new Vector3(0, 0, 0);// transform.forward * 0;
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);// Random.insideUnitSphere * 0;
    }
}
