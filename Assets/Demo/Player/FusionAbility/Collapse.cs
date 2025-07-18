using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Collapse")]
public class Collapse : AbilityData
{
    public int count = 3;
    public int defenseReduction;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (count == 0)
        {
            defenseReduction += 10;
            combatManager.enemy.statusEffects["corrosion"].stack += 20;
            Debug.Log("붕괴 융합특성으로 인해 상대에게 방어력 10 감소 및 부식 20 스택 부여");
            count = 3;
        }
        combatManager.enemy.stats.defense = Mathf.Max(0, combatManager.enemy.stats.defense - defenseReduction);
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}