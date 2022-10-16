using UnityEngine;
using System;

public class BulletPoolProvider
{
    [SerializeField] private BulletPool _enemiesPool;
    [SerializeField] private BulletPool _playerPool;

    //public static BulletPoolProvider Instance { get; private set; }

    //private void Awake()
    //{
    //    Instance = this;
    //}

    public BulletPool GetPool(BulletSide bulletSide)
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

