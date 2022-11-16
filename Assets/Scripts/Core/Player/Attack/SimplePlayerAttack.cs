using Assets.Scripts.Core.Player.Attack.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Attack
{
    public class SimplePlayerAttack : IPlayerAttack
    {
        public void Attack(ObjectPool<Bullet> pool, Vector3 basePosition)
        {
            Bullet bullet = (Bullet)pool.GetObject(basePosition);
            bullet.Hit += pool.ReturnObjectToPool;
        }
    }
}
