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
            combatManager.Log($"ö������ ���� ��밡 �޴� ������"
                +string.Concat(Enumerable.Repeat($"{stack}", damages)) + "���ҵǾ���!");
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
            combatManager.Log($"ö������ ���� �޴� ������"
                + string.Concat(Enumerable.Repeat($"{stack}", damages)) + "���ҵǾ���!");
        }
    }
}