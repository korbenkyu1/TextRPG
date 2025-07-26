using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Burn")]
public class Burn : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.player.stats.health -= stack;
            combatManager.Log($"화상으로 체력이 {stack} 감소되었다!");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            combatManager.Log($"화상으로 적의 체력이 {stack} 감소되었다!");
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
