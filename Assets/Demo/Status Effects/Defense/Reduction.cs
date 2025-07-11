using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Reduction")]
public class Reduction : StatusEffectData
{
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < stack && i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * 0.5f);
                Debug.Log("�氨���� ���� �÷��̾ �޴� ������ 50% ����");
            }
        }
    }
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < stack && i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = (int)(combatManager.enemy.damages[i] * 0.5f);
                Debug.Log("�氨���� ���� ��밡 �޴� ������ 50% ����");
            }
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if (stack > 0)
        {
            stack--;
            Debug.Log("�氨 ���� 1 ����");
        }
    }
}