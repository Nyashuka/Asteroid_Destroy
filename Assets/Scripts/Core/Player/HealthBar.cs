using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Text _healthView;

    private void Start()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        _healthView.text = value.ToString();
    }
}
