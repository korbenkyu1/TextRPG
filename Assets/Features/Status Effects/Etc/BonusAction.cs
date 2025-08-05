using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusAction")]
public class BonusAction : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.remainingAction += 1;
                combatManager.Log("�߰��ൿ���� �߰��ൿ���� 1 �����Ǿ���!");
            }
            else
            {
                combatManager.enemy.remainingAction += 1;
                combatManager.Log("�߰��ൿ���� ���� �߰��ൿ���� 1 �����Ǿ���!");
            }
            stack--;
        }
    }
}