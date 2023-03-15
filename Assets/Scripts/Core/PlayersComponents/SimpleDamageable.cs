
using Assets.Scripts.Core.Battle.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents
{
    public class SimpleDamageable : IDamageable
    {
        private Health _health;
        
        public SimpleDamageable(Health health)
        {
            _health = health;
        }
        
        public void MakeDamage(int damage)
        {
            _health.DecreaseHealth(damage);
        }
    }
}
