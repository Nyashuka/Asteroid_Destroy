using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [SerializeField] private Text _healthText;
    private Health _playerHealth;

    public void Init(Health playerHealth)
    {
        _playerHealth = playerHealth;
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        _healthText.text = value.ToString();
    }
}
