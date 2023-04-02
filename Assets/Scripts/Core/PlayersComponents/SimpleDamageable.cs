using Assets.Scripts.Core.Battle.Abstract;

namespace Core.PlayersComponents
{
    public class SimpleDamageable : IDamageable
    {
        private readonly Health _health;
        
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
