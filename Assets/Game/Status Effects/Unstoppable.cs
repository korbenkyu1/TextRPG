using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Unstoppable")]
public class Unstoppable : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if (stack > 0)
            stack--;
    }
}