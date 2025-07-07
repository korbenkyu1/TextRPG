using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Poison")]
public class Poison : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer) 
        {
            combatManager.player.stats.health -= stack;
            stack = Mathf.Max(0, stack - 1); 
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            stack = Mathf.Max(0, stack - 1);
        }
    }
}
