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
            combatManager.Log("붕괴로 적은 방어력이 10 감소되었고 부식 20 스택을 얻었다!");
            count = 3;
        }
        combatManager.enemy.stats.defense = Mathf.Max(0, combatManager.enemy.stats.defense - defenseReduction);
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}