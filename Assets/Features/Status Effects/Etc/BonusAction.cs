using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusAction")]
public class BonusAction : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.remainingAction += 1;
            stack--;
            combatManager.Log("�߰��ൿ���� �߰��ൿ���� 1 �����Ǿ���!");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            combatManager.enemy.remainingAction += 1;
            stack--;
            combatManager.Log("�߰��ൿ���� ���� �߰��ൿ���� 1 �����Ǿ���!");
        }
    }
}