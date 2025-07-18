using System.Runtime.InteropServices;
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
        Debug.Log($"파열 융합특성으로 인해 상대에게 특수피해 {count * 40} 부여");
        count = 0;
    }
}