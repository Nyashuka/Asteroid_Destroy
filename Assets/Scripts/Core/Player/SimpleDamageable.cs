
using Assets.Scripts.Core.Battle.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.Player
{
    public class SimpleDamageable : IDamageable
    {
        [SerializeField] private Health _health;

        public void MakeDamage(int damage)
        {
            _health.DecreaseHealth(damage);
        }
    }
}
