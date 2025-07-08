using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Weakness")]
public class Weakness : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            int beforePlayerAttack = combatManager.enemy.stats.attack;
            combatManager.player.stats.attack = Mathf.Max(0, beforePlayerAttack - stack);
            Debug.Log($"��ȭ�� ���� �÷��̾��� ���ݷ� {beforePlayerAttack} > {combatManager.player.stats.attack}");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            int beforeEnemyAttack = combatManager.enemy.stats.attack;
            combatManager.enemy.stats.attack = Mathf.Max(0, beforeEnemyAttack - stack);
            Debug.Log($"��ȭ�� ���� ����� ���ݷ� {beforeEnemyAttack} > {combatManager.enemy.stats.attack}");
        }
    }
}
