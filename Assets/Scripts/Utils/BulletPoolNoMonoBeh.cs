using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BulletPoolNoMonoBeh
{
    private Bullet _objectPrefab;
    private readonly int _quantityObjects;

    private readonly Queue<Bullet> _objectsPool = new Queue<Bullet>();

    public BulletPoolNoMonoBeh(Bullet bulletPrefab, int quantityObjects)
    {
        _objectPrefab = bulletPrefab;
        _quantityObjects = quantityObjects;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _quantityObjects; i++)
        {
            _objectsPool.Enqueue(CreateBullet());
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = UnityEngine.Object.Instantiate(_objectPrefab);
        bullet.gameObject.SetActive(false);
        //bullet.HitEvent += ReturnBullet;

        return bullet;
    }

    public Bullet GetBullet(Vector3 position)
    {
        Bullet bullet = _objectsPool.Count == 0 ? CreateBullet() : _objectsPool.Dequeue();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;

        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        _objectsPool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}

