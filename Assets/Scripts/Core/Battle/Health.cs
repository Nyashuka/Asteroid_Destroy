using System;

namespace Core.Battle
{
    public class Health
    {
        public event Action<int> HealthChanged;
        public event Action Death;
        private readonly int _maxHealth;

        private int _currentHealth;
        public int CurrentHealth => _currentHealth;

        public Health(int healthAmount)
        {
            _maxHealth = healthAmount;
            _currentHealth = _maxHealth;
        }

        public void IncreaseHealth()
        {
            if (_currentHealth == _maxHealth)
                return;

            _currentHealth++;

            HealthChanged?.Invoke(_currentHealth);
        }

        public void DecreaseHealth(int countHealth)
        {
            _currentHealth -= countHealth;

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

    }
}
