using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Weakness")]
public class Weakness : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.stats.attack = Mathf.Max(0, combatManager.player.stats.attack - stack);
            Debug.Log($"��ȭ�� ���� �÷��̾��� ���ݷ� {stack} ����");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.attack = Mathf.Max(0, combatManager.enemy.stats.attack - stack);
            Debug.Log($"��ȭ�� ���� ����� ���ݷ� {stack} ����");
        }
    }
}
