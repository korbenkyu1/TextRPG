using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/EvasionChance")]
public class EvasionChance : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(!isPlayer)
            {
                combatManager.enemy.stats.dodgeChance = Mathf.Min(70, combatManager.enemy.stats.dodgeChance + stack);
            }
            else if (isPlayer)
            {
                combatManager.player.stats.dodgeChance = Mathf.Min(70, combatManager.player.stats.dodgeChance + stack);
            }
        }
    }
}