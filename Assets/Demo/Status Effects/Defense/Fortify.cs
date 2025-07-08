using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Fortify")]
public class Fortify : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {

        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {

        }
    }
}