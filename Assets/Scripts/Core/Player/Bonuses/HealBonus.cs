using UnityEngine;

public class HealBonus : BattleBonus
{
    protected override void ApplyBonus(Player player)
    {
        player.Heal();
    }
}
