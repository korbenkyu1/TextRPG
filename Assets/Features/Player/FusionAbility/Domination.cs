using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Domination")]
public class Domination : AbilityData
{
    int attackReduction;
    public override void OnTurnStart(CombatManager combatManager)
    {
        attackReduction += 4;
        combatManager.enemy.stats.attack = Mathf.Max(0, combatManager.enemy.stats.attack - attackReduction);
        combatManager.Log("장악으로 적의 공격력이 4 감소되었다!");
    }
}