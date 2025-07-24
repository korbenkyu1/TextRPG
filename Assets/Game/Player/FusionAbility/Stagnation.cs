using System.Runtime.InteropServices;
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
            Debug.Log("정체 융합특성으로 인해 상대에게 마비 1 스택 부여");
        }
    }
}