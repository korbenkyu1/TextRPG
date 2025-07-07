using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Vampirism")]
public class Vampirism : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            
        }
    }
}