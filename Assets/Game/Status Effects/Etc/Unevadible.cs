using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Unevadible")]
public class Unevadible : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.dodgeChance -= stack * 100;
                Debug.Log($"ȸ�ǺҰ��� ���� �÷��̾��� ȸ���� {stack * 100}%p ����");
            }
            if(!isPlayer)
            {
                combatManager.enemy.stats.dodgeChance -= stack * 100;
                Debug.Log($"ȸ�ǺҰ��� ���� ����� ȸ���� {stack * 100}%p ����");
            }
        }
    }
}