using System;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage();
        }
    }
}

