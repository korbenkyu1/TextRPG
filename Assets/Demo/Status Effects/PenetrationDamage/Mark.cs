using UnityEngine;

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
                Debug.Log("ǥ������ ���� ���� 30% �߰� �������� �Դ´�");
            }
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < stack && i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * 1.3f);
                Debug.Log("ǥ������ ���� �÷��̾�� 30% �߰� �������� �Դ´�");
            }
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
        {
            stack--;
            Debug.Log("ǥ�� ���� 1 ����");
        }
    }
}