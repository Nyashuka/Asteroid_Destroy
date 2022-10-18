using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _attackCooldown;

    private BulletPoolNoMonoBeh _bulletPoolNoMonoBeh;

    private float _nextAttackTime = 0;

    public event Action<Enemy> KilledEnemy;

    private void Start()
    {
        _bulletPoolNoMonoBeh = new BulletPoolNoMonoBeh(_bulletPrefab, 20);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0) && _nextAttackTime < Time.time)
        {
            _nextAttackTime = Time.time + _attackCooldown;

            Bullet bullet = _bulletPoolNoMonoBeh.GetBullet(_bulletSpawnPosition.position);
            bullet.Init(_bulletPoolNoMonoBeh);
            bullet.SetKillAction(KilledEnemy);
        }
    }


}
