using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Shield")]
public class Shield : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.enemy.damages.Count && stack > 0; i++, stack--)
            {
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.enemy.damages[i] - stack);
            }
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count && stack > 0; i++, stack--)
            {
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
            }
        }
    }
}