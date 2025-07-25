using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Restrain")]
public class Restrain : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.enemy.damages.Count; i++)
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.enemy.damages[i] - stack);
            combatManager.Log($"�������� ���� �޴� �������� {stack} ���ҵǾ���!");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
            combatManager.Log($"�������� �޴� ������ {stack} ���ҵǾ���!");
        }
    }
}