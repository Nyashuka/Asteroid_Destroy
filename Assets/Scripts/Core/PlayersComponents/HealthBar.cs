using UnityEngine;
using UnityEngine.UI;

namespace Core.PlayersComponents
{
    public class HealthBar : MonoBehaviour
    {   
        [SerializeField] private Text healthText;
        private Health _playerHealth;

        public void Init(Health playerHealth)
        {
            _playerHealth = playerHealth;
            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            healthText.text = value.ToString();
        }
    }
}
