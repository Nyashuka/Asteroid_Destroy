using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [SerializeField] private Text _healthView;
    private Health _playerHealth;

    private void Init(Health playerHealth)
    {
        _playerHealth = playerHealth;
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        _healthView.text = value.ToString();
    }
}
