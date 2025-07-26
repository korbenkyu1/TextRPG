using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Reduction")]
public class Reduction : StatusEffectData
{
    public int count = 0;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * 0.5f);
                if (i + 1 > stack)
                    count++;
            }
            combatManager.Log("경감으로 인해 받는 데미지 " + string.Concat(Enumerable.Repeat("50% ", count))
                + string.Concat(Enumerable.Repeat("0 ", combatManager.player.damages.Count - count))+"감소되었다!");
            count = 0;
        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = (int)(combatManager.enemy.damages[i] * 0.5f);
                if (i + 1 > stack)
                    count++;
            }
            combatManager.Log("경감으로 인해 적이 받는 데미지 " + string.Concat(Enumerable.Repeat("50% ", count))
                + string.Concat(Enumerable.Repeat("0 ", combatManager.player.damages.Count - count)) + "감소되었다!");
            count = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if (stack > 0)
        {
            stack--;
        }
    }
}