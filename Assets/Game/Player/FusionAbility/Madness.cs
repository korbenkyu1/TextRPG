using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Madness")]
public class Madness : AbilityData
{
    public int count;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        count += combatManager.player.damages.Count;
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= count * 40;
        combatManager.Log($"����� ���� ü���� {count * 40} ���ҵǾ���!");
        count = 0;
    }
}