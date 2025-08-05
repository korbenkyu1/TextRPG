using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/Act4Shared")]
public class Act4SharedAbility : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 10);
        combatManager.Log("�����ҳ��� ��ȣ�� ���� ü���� 10 ȸ���Ǿ���!");
    }
}