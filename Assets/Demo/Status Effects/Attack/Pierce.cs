using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Pierce")]
public class Pierce : StatusEffectData
{
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {

        }
    }
}
