using UnityEngine;

public class BonusData
{
    public readonly GameObject prefab;
    public readonly int dropChance = 10;

    public BonusData(GameObject bonusPrefab, int dropChance)
    {
        this.prefab = bonusPrefab;
        this.dropChance = dropChance;
    }
}
