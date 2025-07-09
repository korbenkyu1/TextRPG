using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusDefense")]
public class BonusDefense : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager) { if (stack > 0) stack = 0; }
}