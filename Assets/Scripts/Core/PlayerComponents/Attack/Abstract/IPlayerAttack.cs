using Core.Battle;
using UnityEngine;
using Utils;

namespace Assets.Scripts.Core.PlayersComponents.Attack.Abstract
{
    public interface IPlayerAttack
    {
        void Attack(ObjectPool<Bullet> pool, Vector3 basePosition);
    }
}
