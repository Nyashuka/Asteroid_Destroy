using System;
using Core.PlayerComponents.Bonuses;
using UnityEngine;

namespace Core.Factory
{
    [Serializable]
    public class BonusData
    {
        [SerializeField] private BuffContainer prefab;
        [SerializeField] private int dropChance;

        public BuffContainer Prefab => prefab;
        public int DropChance => dropChance;
    
        public BonusData(BuffContainer bonusPrefab, int dropChance)
        {
            prefab = bonusPrefab;
            this.dropChance = dropChance;
        }
    }
}
