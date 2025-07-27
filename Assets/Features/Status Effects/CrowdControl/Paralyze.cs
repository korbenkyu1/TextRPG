using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Paralyze")]
public class Paralyze : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer && combatManager.player.statusEffects["unstoppable"].stack <= 0)
        {
            combatManager.player.remainingAction = 0;
            combatManager.Log($"����� �ൿ�� �� ������!");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer && combatManager.enemy.statusEffects["unstoppable"].stack <= 0)
        {
            combatManager.enemy.remainingAction = 0;
            combatManager.Log($"����� ���� �ൿ�� �� ������!");
        }
    }
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
            stack--;
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
            stack--;
    }
}
