using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Fortify")]
public class Fortify : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            var damages = combatManager.enemy.damages.Count;
            for (int i = 0; i < damages; i++)
            {
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.enemy.damages[i] - stack);
            }
            combatManager.Log($"철갑으로 인해 상대가 받는 데미지"
                +string.Concat(Enumerable.Repeat($"{stack}", damages)) + "감소되었다!");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            var damages = combatManager.player.damages.Count;
            for (int i = 0; i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
            }
            combatManager.Log($"철갑으로 인해 받는 데미지"
                + string.Concat(Enumerable.Repeat($"{stack}", damages)) + "감소되었다!");
        }
    }
}