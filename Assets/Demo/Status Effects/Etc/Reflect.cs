using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Reflect")]
public class Reflect : StatusEffectData
{
    int damageCount = 0;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.player.damages.Count; i++)
            {
                if (combatManager.player.damages[i] > 0)
                    damageCount++;
            }
        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                if (combatManager.enemy.damages[i] > 0)
                    damageCount++;
            }
        }
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        if(damageCount > 0)
        {
            for(int i = 0; i < damageCount; i++)
            {
                combatManager.player.stats.health -= stack;
                Debug.Log($"�ݻ�� ���� ���� {stack}�� �������� �Ծ���");
            }
            damageCount = 0;
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if (damageCount > 0)
        {
            for (int i = 0; i < damageCount; i++)
            {
                combatManager.player.stats.health -= stack;
                Debug.Log($"�ݻ�� ���� �÷��̾�� {stack}�� �������� �Ծ���");
            }
            damageCount = 0;
        }
    }
}