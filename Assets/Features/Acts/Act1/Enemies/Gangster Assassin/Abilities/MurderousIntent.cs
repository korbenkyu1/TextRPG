using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/MurderousIntent")]
public class MurderousIntent : AbilityData
{
    public int count = 0;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        count = combatManager.player.damages.Count;
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["eternal_bonus_damage"].stack += count;
        combatManager.Log($"���Ƿ� ����� ���ݷ��� {count} �����Ǿ���!");
        count = 0;
    }
}