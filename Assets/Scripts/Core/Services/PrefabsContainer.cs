using Core.Services.ServiceLocatorSystem;
using DataStructures.Scriptable;
using UnityEngine;

namespace Services
{
    public class PrefabsContainer : MonoBehaviour, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        [SerializeField] private GameAssetReferencesScriptableObject gameData;
        [SerializeField] private UIAssetReferencesScriptableObject uiData;

        public GameAssetReferencesScriptableObject GameData => gameData;
        public UIAssetReferencesScriptableObject UIData => uiData;
    }
}
