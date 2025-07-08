using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Unevadible")]
public class Unevadible : StatusEffectData
{
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.stats.dodgeChance -= stack * 100;
            Debug.Log($"ȸ�ǺҰ��� ���� �÷��̾��� ȸ���� {stack * 100}%p ����");
        }
    }
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.enemy.stats.dodgeChance -= stack * 100;
            Debug.Log($"ȸ�ǺҰ��� ���� ����� ȸ���� {stack * 100}%p ����");
        }
    }
}