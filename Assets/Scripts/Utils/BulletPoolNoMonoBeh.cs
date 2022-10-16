using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BulletPoolNoMonoBeh
{
    private Bullet _bulletPrefab;
    private const int QUANTITY_BULLETS = 100;

    private readonly Queue<Bullet> _bulletsPool = new Queue<Bullet>();

    public BulletPoolNoMonoBeh(Bullet bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < QUANTITY_BULLETS; i++)
        {
            _bulletsPool.Enqueue(CreateBullet());
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = UnityEngine.Object.Instantiate(_bulletPrefab);
        bullet.gameObject.SetActive(false);

        return bullet;
    }

    public Bullet GetBullet(Vector3 position)
    {
        Bullet bullet = _bulletsPool.Count == 0 ? CreateBullet() : _bulletsPool.Dequeue();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;

        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        _bulletsPool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}

