using Assets.Scripts.Core.Battle.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.Battle
{
    public class SimpleDamager : IDamager
    {
        private int _damage;

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
