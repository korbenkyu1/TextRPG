using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/BrandStack")]
public class BrandStack : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        stack--;
        if (stack == 0)
            combatManager.enemy.stats.health -= 777;
    }
}