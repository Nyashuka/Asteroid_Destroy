using UnityEngine;
using System;

public class BulletPoolProvider : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemiesPool;
    [SerializeField] private ObjectPool _playerPool;

    //public static BulletPoolProvider Instance { get; private set; }

    //public void Awake()
    //{
    //    Instance = this;
    //}

    public ObjectPool GetPool(BulletSide bulletSide)
    {
        switch(bulletSide)
        {
            case BulletSide.Player:
                return _playerPool;
            case BulletSide.Enemy:
                return _enemiesPool;
            default:
                throw new ArgumentOutOfRangeException("No this side");
        }
    }
}

