using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Services.Scriptable
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameAssetRefferencesScriptableObject")]
    public class GameAssetRefferencesScriptableObject : ScriptableObject
    {
        [SerializeField] private AssetReference _playerPrefabAssetReference;
        [SerializeField] private AssetReference _enemyPrefabAssetReference;
        [SerializeField] private AssetReference _playerUIAssetReference;
        

        [SerializeField] private UnitySerializedDictionary<AssetReference, int> _bonuses;
        
        public AssetReference PlayerPrefabAssetReference => _playerPrefabAssetReference;
        public AssetReference EnemyPrefabAssetReference => _enemyPrefabAssetReference;
        public AssetReference PlayerUIAssetReference => _playerUIAssetReference;
        public UnitySerializedDictionary<AssetReference, int> Bonuses => _bonuses;

    }
}
