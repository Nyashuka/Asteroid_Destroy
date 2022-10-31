using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerGun _playerGun;

    public event Action DeathEvent;

    public void Start()
    {
        _health.Death += AnnounceDeath;
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
