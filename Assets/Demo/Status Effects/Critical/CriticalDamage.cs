using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Critical/CriticalDamage")]
public class CriticalDamage : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {

        }
    }
}