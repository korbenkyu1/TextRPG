using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/BonusEvasion")]
public class BonusEvasion : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer) stack = 0;
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer) stack = 0;
    }
}