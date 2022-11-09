using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _tumble;

    private void Start()
    {
        ServicesProvider.Instance.PauseManager.Register(this);

        PushAsteroid();
    }

    private void OnDisable()
    {
        ServicesProvider.Instance.PauseManager.UnRegister(this);
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
        _rigidbody.velocity = transform.forward * 0;
        _rigidbody.angularVelocity = Random.insideUnitSphere * 0;
    }
}
