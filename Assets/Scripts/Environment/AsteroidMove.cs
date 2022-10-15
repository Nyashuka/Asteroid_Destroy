using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _tumble;

    public void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
        _rigidbody.angularVelocity = Random.insideUnitSphere * _tumble;
    }
}
