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
        HealthChanged += DebugHealth;
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
        if (_currentHealth == 0)
            Death?.Invoke();

        _currentHealth--;

        HealthChanged?.Invoke(_currentHealth);
    }

    private void DebugHealth(int a)
    {
        Debug.Log(gameObject);
        Debug.Log(_currentHealth);
    }
}
