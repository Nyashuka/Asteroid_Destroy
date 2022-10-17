using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    public event Action DeathEvent;
    public event Action<IEnemy> KillEnemy;

    public void Start()
    {
        _health.OnDeath += AnnounceDeath;
    }

    public void GetDamage()
    {
        _health.DecreaseHealth();
    }

    private void AnnounceDeath()
    {
        DeathEvent?.Invoke();
    }

    
}
