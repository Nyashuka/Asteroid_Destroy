using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerGun _playerGun;

    public event Action DeathEvent;
    public event Action<Enemy> KilledEnemy;


    public void Start()
    {
        _health.Death += AnnounceDeath;
        _playerGun.KilledEnemy += AnnounceKill;
    }
    private void AnnounceKill(Enemy killedEnemy)
    {
        KilledEnemy?.Invoke(killedEnemy);
    }

    public void GetDamage()
    {
        _health.DecreaseHealth();
    }

    private void AnnounceDeath()
    {
        DeathEvent?.Invoke();
    }

    bool IDamageable.TryDamageOrKill()
    {
        throw new NotImplementedException();
    }
}
