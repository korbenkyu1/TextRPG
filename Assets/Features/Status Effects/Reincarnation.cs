using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Reincarnation")]
public class Reincarnation : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && combatManager.enemy.stats.health <= 0)
        {
            combatManager.enemy.stats.health = stack;
            combatManager.Log($"상대는 {stack}의 체력으로 부활했다!");
            stack = 0;
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && combatManager.enemy.stats.health <= 0)
        {
            combatManager.enemy.stats.health = stack;
            combatManager.Log($"상대는 {stack}의 체력으로 부활했다!");
            stack = 0;
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && combatManager.enemy.stats.health <= 0)
        {
            combatManager.enemy.stats.health = stack;
            combatManager.Log($"상대는 {stack}의 체력으로 부활했다!");
            stack = 0;
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && combatManager.enemy.stats.health <= 0)
        {
            combatManager.enemy.stats.health = stack;
            combatManager.Log($"상대는 {stack}의 체력으로 부활했다!");
            stack = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && combatManager.enemy.stats.health <= 0)
        {
            combatManager.enemy.stats.health = stack;
            combatManager.Log($"상대는 {stack}의 체력으로 부활했다!");
            stack = 0;
        }
    }
}