using Assets.Scripts.Core.PlayersComponents;
using Core.Enemies;
using Core.Factory;
using Core.PlayerComponents;
using Core.PlayersComponents.Bonuses;
using Core.PlayersComponents.Bonuses.Abstract;
using UIModule;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Utils;

namespace DataStructures.Scriptable
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameAssetReferencesScriptableObject")]
    public class GameAssetReferencesScriptableObject : ScriptableObject
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private PlayerHUD playerHUD;
        [SerializeField] private ScreenBoundary screenBoundary;

        [SerializeField] private BonusData[] bonuses;
        
        public Player PlayerPrefab => playerPrefab;
        public Enemy EnemyPrefab => enemyPrefab;
        public PlayerHUD PlayerUIAssetReference => playerHUD;
        public ScreenBoundary ScreenBoundaryPrefab => screenBoundary;
        
        public BonusData[] Bonuses => bonuses;

    }
}
