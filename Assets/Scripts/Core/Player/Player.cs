using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealeable
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerGun _playerGun;
    [SerializeField] private GameObject _deathVFX;
    public Health Health => _health;

    public event Action DeathEvent;

    public void Start()
    {
        _health.Death += OnDeath;
    }

    private void OnDeath()
    {
        Destroy(Instantiate(_deathVFX, transform.position, transform.rotation), 1f);
        AnnounceDeath();
    }

    public void GetDamage()
    {
        _health.DecreaseHealth();
    }

    public void Heal()
    {
        _health.IncreaseHealth();
    }

    private void AnnounceDeath()
    {
        DeathEvent?.Invoke();
    }
}
