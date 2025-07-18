using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Madness")]
public class Madness : AbilityData
{
    int count;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        count += combatManager.player.damages.Count;
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= count * 40;
        Debug.Log($"�÷��̾��� ���� ����Ư������ ���� ���� {count * 40}�� �������� �Ծ���");
        count = 0;
    }
}