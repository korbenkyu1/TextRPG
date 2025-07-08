using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Reduction")]
public class Reduction : StatusEffectData
{
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {

        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {

        }
    }
}