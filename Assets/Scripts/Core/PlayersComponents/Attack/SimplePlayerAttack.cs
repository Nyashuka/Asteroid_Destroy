using Assets.Scripts.Core.PlayersComponents.Attack.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.Attack
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
