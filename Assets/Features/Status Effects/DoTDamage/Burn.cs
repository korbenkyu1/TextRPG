using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Burn")]
public class Burn : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.player.stats.health -= stack;
            combatManager.Log($"ȭ������ ü���� {stack} ���ҵǾ���!");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            combatManager.Log($"ȭ������ ���� ü���� {stack} ���ҵǾ���!");
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            stack--;
        }
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            stack--;
        }
    }
}
