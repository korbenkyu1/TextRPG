using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Critical/CriticalChance")]
public class CriticalChance : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            if (combatManager.player.stats.critChance + stack > 99)
                combatManager.player.stats.critChance = 99;
            else
                combatManager.player.stats.critChance += stack;
            Debug.Log($"치명타 확률 증가로 인해 플레이어의 치명타 확률 {stack}%p 상승");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            if (combatManager.enemy.stats.critChance + stack > 99)
                combatManager.enemy.stats.critChance = 99;
            else
                combatManager.enemy.stats.critChance += stack;
            Debug.Log($"치명타 확률 증가로 인해 상대의 치명타 확률 {stack}%p 상승");
        }
    }
}
