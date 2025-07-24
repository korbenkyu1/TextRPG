using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusDamage")]
public class BonusDamage : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager) { if (stack > 0) stack = 0; }
}