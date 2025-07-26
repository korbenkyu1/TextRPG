using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Rupture")]
public class Rupture : AbilityData
{
    public int count;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        count = combatManager.enemy.damages.Count;
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= count * 40;
        combatManager.Log($"파열으로 인해 적의 체력이 {count * 40} 감소되었다!");
        count = 0;
    }
}