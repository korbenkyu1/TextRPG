using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/EternalBonusDefense")]
public class EternalBonusDefense : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if (isPlayer) combatManager.player.stats.defense = Mathf.Min(70, combatManager.player.stats.defense + stack);
            else if (!isPlayer) combatManager.enemy.stats.defense = Mathf.Min(70, combatManager.enemy.stats.defense + stack);
        }
    }
}