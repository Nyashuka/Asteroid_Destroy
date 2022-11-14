using Assets.Scripts.Core.Player.Bonuses;
using Assets.Scripts.Core.Player.Bonuses.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealeable
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerGun _playerGun;
    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private List<TimedBuff> _buffs;
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

    private void OnTriggerEnter(Collider other)
    {
        // other.TryGetValue<IPermanentBuff>(out var permanent)
        // other.TryGetValue<ITimedBuff>(out var timed)

        if (other.TryGetComponent(out BuffContainer buffContainer))
        {
            BuffEffect buff = buffContainer.GetBuff();

            if (buff is PermanentBuff)
            {
                buff.Apply();
            }    
            else
            {
                _buffs.Add((TimedBuff)buff);
            }
                
        }
    }
}
