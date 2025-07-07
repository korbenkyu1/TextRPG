using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Burn")]
public class Burn : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.player.stats.health -= stack;
            Debug.Log($"�÷��̾�� {stack}�� ȭ�� �������� �Ծ���");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            Debug.Log($"���� {stack}�� ȭ�� �������� �Ծ���");
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"�÷��̾��� ȭ�� ���� {stack + 1} >> {stack}");
        }
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"����� ȭ�� ���� {stack + 1} >> {stack}");
        }
    }
}
