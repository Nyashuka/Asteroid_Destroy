using Assets.Scripts.Core.PlayersComponents;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services.ServiceLocatorSystem;
using UnityEngine;

namespace Core.Factory
{
    public class PlayerFactory : IService
    {
        private readonly Player _playerPrefab;
        private Player _player;

        public PlayerFactory(Player playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public Player Create()
        {
            if (_player != null)
                return _player;

            _player = Object.Instantiate(_playerPrefab);
            return _player;
        }
    }
}
