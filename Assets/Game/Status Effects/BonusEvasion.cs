using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/BonusEvasion")]
public class BonusEvasion : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
            stack = 0;
    }
}