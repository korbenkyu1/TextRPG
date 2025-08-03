using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/HaYoonAbility")]
public class HaYoonAbility : AbilityData
{
    int count = 0;
    public override void OnTurnStart(CombatManager combatmanager)
    {
        count++;
        if (count == 2)
        {
            combatmanager.enemy.stats.maxHealth += 30;
            combatmanager.enemy.stats.health += 30;
            combatmanager.Log("�����ҳ� ������ Ư������ ���� �ִ�ü���� 30 �����Ǿ���!");
            count = 0;
        }
    }
}