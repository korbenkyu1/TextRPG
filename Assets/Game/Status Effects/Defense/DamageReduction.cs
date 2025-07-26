using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/DamageReduction")]
public class DamageReduction : StatusEffectData
{
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.damages[0] = (int)(Mathf.Max(0, combatManager.player.damages[0] - stack));
            combatManager.Log($"피해감소로 인해 받는 데미지가 {stack} 감소되었다!");
            stack = 0;
        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.damages[0] = (int)(Mathf.Max(0, combatManager.enemy.damages[0] - stack));
            combatManager.Log($"피해감소로 인해 적이 받는 데미지가 {stack} 감소되었다!");
            stack = 0;
        }
    }
}