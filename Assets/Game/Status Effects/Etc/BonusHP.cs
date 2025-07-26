using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusHP")]
public class BonusHP : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.maxHealth = Mathf.Min(900, combatManager.player.stats.maxHealth + stack);
            }
            else if(!isPlayer)
            {
                combatManager.enemy.stats.maxHealth = Mathf.Min(900, combatManager.enemy.stats.maxHealth + stack);
            }
        }
    }
}