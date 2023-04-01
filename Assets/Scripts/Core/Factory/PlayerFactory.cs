using Assets.Scripts.Core.PlayersComponents;
using Assets.Scripts.Services.ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Core.Factory
{
    public class PlayerFactory : IService
    {
        private GameObject _playerPrefab;
        private Player _player;

        public PlayerFactory(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;

        }

        public Player Create()
        {

            if (_player != null)
                return _player;

            _player = MonoBehaviour.Instantiate(_playerPrefab).GetComponent<Player>();
            return _player;
        }
    }
}
