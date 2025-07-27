using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Stagnation")]
public class Stagnation : AbilityData
{
    public int count = 4;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        count -= combatManager.enemy.damages.Count;
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        while(count <= 0)
        {
            count += 4;
            combatManager.enemy.statusEffects["paralyze"].stack++;
            combatManager.Log("적이 정체로 인해 마비 1 스택을 얻었다!");
        }
    }
}