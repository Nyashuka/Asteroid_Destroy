using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Services.Scriptable
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameAssetRefferencesScriptableObject")]
    public class GameAssetRefferencesScriptableObject : ScriptableObject
    {
        [SerializeField] private AssetReference playerPrefabAssetReference;
        [SerializeField] private AssetReference enemyPrefabAssetReference;
        [SerializeField] private AssetReference playerUIAssetReference;
        

        [SerializeField] private UnitySerializedDictionary<AssetReference, int> _bonuses;
        
        public AssetReference PlayerPrefabAssetReference => playerPrefabAssetReference;
        public AssetReference EnemyPrefabAssetReference => enemyPrefabAssetReference;
        public AssetReference PlayerUIAssetReference => playerUIAssetReference;
        public UnitySerializedDictionary<AssetReference, int> Bonuses => _bonuses;

    }
}
