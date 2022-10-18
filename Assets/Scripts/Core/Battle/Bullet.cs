using System;
using UnityEngine;

public class Bullet : PlayerDamager, IPoolObject
{
    private BulletPoolNoMonoBeh _bulletPool;

    public void Init(BulletPoolNoMonoBeh bulletPool)
    {
        _bulletPool = bulletPool;
    }
}

