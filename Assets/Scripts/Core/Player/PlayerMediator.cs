using UnityEngine;

namespace Assets.Scripts.Core.Player
{
    public class PlayerMediator : MonoBehaviour
    {
        [SerializeField] private PlayerGun _playerGun;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private Health _health;
        [SerializeField] private HealthBar _healthBar;
        
        private void Start()
        {
        }
    }
}
