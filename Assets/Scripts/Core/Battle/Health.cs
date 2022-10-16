using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> OnHealthChanged;
    public event Action OnDeath;

    [SerializeField] private readonly int _maxHealth;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void IncreaseHealth()
    {
        if (_currentHealth == _maxHealth)
            return;

        _currentHealth++;

        OnHealthChanged?.Invoke(_currentHealth);
    }

    private void DecreaseHealt()
    {
        if (_currentHealth == 0)
            OnDeath?.Invoke();

        _currentHealth--;

        OnHealthChanged?.Invoke(_currentHealth);
    }
}
