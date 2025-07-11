using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Critical/CriticalChance")]
public class CriticalChance : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatmanager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatmanager.player.stats.critChance = Mathf.Min(99, combatmanager.player.stats.critChance + stack);
            }
            else if (!isPlayer)
            {
                combatmanager.enemy.stats.critChance = Mathf.Min(99, combatmanager.enemy.stats.critChance + stack);
            }
        }
    }
}
