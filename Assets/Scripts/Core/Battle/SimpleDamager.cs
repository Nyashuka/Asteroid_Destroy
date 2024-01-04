using Core.Battle.Abstract;
using UnityEngine;

namespace Core.Battle
{
    public class SimpleDamager : IDamager
    {
        private readonly int _damage;

        public SimpleDamager(int damage)
        {
            _damage = damage;
        }

        public void DoDamage(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.MakeDamage(_damage);
            }
        }
    }
}
