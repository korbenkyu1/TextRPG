using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/PenetrationDamage/Corrosion")]
public class Corrosion : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            for(int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = (int)(combatManager.enemy.damages[i] * (100 + stack) / 100f);
            }
            combatManager.Log($"�ν����� ���� �޴� �������� {stack}% �����Ǿ���!");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * (100 + stack) / 100f);
            }
            combatManager.Log($"�ν����� �޴� �������� {stack}% �����Ǿ���!");
        }
    }
}