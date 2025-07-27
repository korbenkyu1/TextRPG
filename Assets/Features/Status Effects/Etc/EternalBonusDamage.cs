using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/EternalBonusDamage")]
public class EternalBonusDamage : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if (isPlayer) combatManager.player.stats.attack = Mathf.Min(70, combatManager.player.stats.attack + stack);
            else if (!isPlayer) combatManager.enemy.stats.attack = Mathf.Min(70, combatManager.enemy.stats.attack + stack);
        }
    }
}