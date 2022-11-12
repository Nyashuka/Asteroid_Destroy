using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform _parentForPoolObjects;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private WorldBoundary _worldBoundary;

    private ObjectPool<Bullet> _bulletPool;

    private float _nextAttackTime = 0;

    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, 20, _parentForPoolObjects);
        _worldBoundary.LeftWorld += _bulletPool.ReturnObjectToPool;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        if (_nextAttackTime > Time.time)
            return;

        _nextAttackTime = Time.time + _attackCooldown;

        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) || Input.touchCount == 1)
        {
            Bullet bullet = (Bullet)_bulletPool.GetObject(_bulletSpawnPosition.position);
            bullet.Hit += _bulletPool.ReturnObjectToPool;
        }
    }

}
