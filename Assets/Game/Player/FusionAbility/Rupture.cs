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
        combatManager.Log($"�Ŀ����� ���� ���� ü���� {count * 40} ���ҵǾ���!");
        count = 0;
    }
}