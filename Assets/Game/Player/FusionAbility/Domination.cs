using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Domination")]
public class Domination : AbilityData
{
    int attackReduction;
    public override void OnTurnStart(CombatManager combatManager)
    {
        attackReduction += 4;
        combatManager.enemy.stats.attack = Mathf.Max(0, combatManager.enemy.stats.attack - attackReduction);
        Debug.Log("장악 융합특성으로 인해 상대의 공격력 4 감소");
    }
}