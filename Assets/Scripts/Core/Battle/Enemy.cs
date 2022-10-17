using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    public void GetDamage()
    {
        _health.DecreaseHealth();
    }


}

