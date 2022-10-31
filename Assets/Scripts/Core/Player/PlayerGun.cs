using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject _parentForPoolObjects;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _attackCooldown;

    private ObjectPool _bulletPoolNoMonoBeh;

    private float _nextAttackTime = 0;


    private void Start()
    {
        _bulletPoolNoMonoBeh = new ObjectPool(_bulletPrefab, 20, _parentForPoolObjects);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && _nextAttackTime < Time.time)
        {
            _nextAttackTime = Time.time + _attackCooldown;

            Bullet bullet = (Bullet)_bulletPoolNoMonoBeh.GetObject(_bulletSpawnPosition.position);
            bullet.Hit += _bulletPoolNoMonoBeh.ReturnObjectToPool;
        }
    }
}
