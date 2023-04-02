using Assets.Scripts.Services.Scriptable;
using Assets.Scripts.Services.ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class PrefabsContainer : MonoBehaviour, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        [SerializeField] private GameAssetRefferencesScriptableObject gameData;

        public GameAssetRefferencesScriptableObject GameData => gameData;
    }
}
