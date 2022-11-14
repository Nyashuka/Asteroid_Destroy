using Assets.Scripts.Core.Player.Attack.Abstract;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Attack
{
    public class SimplePlayerAttack : IPlayerAttack
    {
        public void Attack(ObjectPool<Bullet> pool, Transform basePosition)
        {
            Bullet bullet = (Bullet)pool.GetObject(basePosition.position);
            bullet.Hit += pool.ReturnObjectToPool;
        }
    }
}
