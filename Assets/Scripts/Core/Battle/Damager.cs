using Core.Battle.Abstract;
using UnityEngine;

namespace Core.Battle
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int damage;
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.MakeDamage(damage);
            }
        }
    }
}

