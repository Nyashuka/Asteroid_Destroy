using Assets.Scripts.Core.Battle.Abstract;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.MakeDamage(_damage);
        }
    }
}

