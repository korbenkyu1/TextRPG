using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Critical/CriticalDamage")]
public class CriticalDamage : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {

        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {

        }
    }
}