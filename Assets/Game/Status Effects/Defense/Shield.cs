using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Shield")]
public class Shield : StatusEffectData
{
    public List<int> damageReduction = new();
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.enemy.damages[i] - stack);               
                damageReduction.Add(stack);
                stack = Mathf.Max(0, stack - 1);
            }
            combatManager.Log("보호로 인해 적이 받는 피해가 "+string.Join(" ", damageReduction) + " 감소되었다!");
            damageReduction.Clear();
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
                damageReduction.Add(stack);
                stack = Mathf.Max(0, stack - 1);
            }
            combatManager.Log("보호로 인해 받는 피해가 " + string.Join(" ", damageReduction) + " 감소되었다!");
            damageReduction.Clear();
        }
    }
}