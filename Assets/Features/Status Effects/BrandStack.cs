using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/BrandStack")]
public class BrandStack : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        stack--;
        if (stack == 0)
        {
            combatManager.enemy.stats.health -= 777;
            combatManager.Log("낙인으로 적의 체력이 777 감소되었다!");
        }
    }
}