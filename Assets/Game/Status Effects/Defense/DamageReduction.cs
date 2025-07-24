using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/DamageReduction")]
public class DamageReduction : StatusEffectData
{
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.damages[0] = (int)(Mathf.Max(0, combatManager.player.damages[0] - stack));
            Debug.Log($"���ذ��ҷ� ���� �÷��̾ �޴� ������ {stack} ����");
            stack = 0;
        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.damages[0] = (int)(Mathf.Max(0, combatManager.enemy.damages[0] - stack));
            Debug.Log($"���ذ��ҷ� ���� ��밡 �޴� ������ {stack} ����");
            stack = 0;
        }
    }
}