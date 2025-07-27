using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Data/StatusEffect/PenetrationDamage/Mark")]
public class Mark : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            for(int i = 0; i < stack && i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = (int)(combatManager.enemy.damages[i] * 1.3f);
            }
            combatManager.Log("표식으로 적이 받는 데미지가 "+string.Concat(Enumerable.Repeat("30% ", stack))
                +string.Concat(Enumerable.Repeat("0% ", combatManager.enemy.damages.Count-stack))+"증가되었다!");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < stack && i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * 1.3f);
            }
            combatManager.Log("표식으로 받는 데미지가 " + string.Concat(Enumerable.Repeat("30% ", stack))
                + string.Concat(Enumerable.Repeat("0% ", combatManager.enemy.damages.Count - stack)) + "증가되었다!");
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
        {
            stack--;
        }
    }
}