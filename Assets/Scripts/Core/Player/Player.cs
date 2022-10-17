using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private IDamager _playerGun;

    public event Action DeathEvent;
    public event Action<IEnemy> KillEnemy;


    public void Start()
    {
        _health.OnDeath += AnnounceDeath;
        десь.Killed += AnnounceKill;
    }
    private void AnnounceDeath(IEnemy killedEnemy)
    {
        KillEnemy?.Invoke(killedEnemy);
    }

    public void GetDamage()
    {
        _health.DecreaseHealth();
    }

    private void AnnounceDeath()
    {
        DeathEvent?.Invoke();
    }

    bool IDamageable.GetDamage()
    {
        throw new NotImplementedException();
    }
}
