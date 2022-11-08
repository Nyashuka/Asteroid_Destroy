using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> HealthChanged;
    public event Action Death;

    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth()
    {
        if (_currentHealth == _maxHealth)
            return;

        _currentHealth++;

        HealthChanged?.Invoke(_currentHealth);
    }

    public void DecreaseHealth()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Death?.Invoke();
        }

        HealthChanged?.Invoke(_currentHealth);
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
    }

    public void MakeDamage()
    {
        DecreaseHealth();
    }
}
