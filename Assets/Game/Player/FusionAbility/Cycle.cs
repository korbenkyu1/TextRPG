using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Cycle")]
public class Cycle : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 15;
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health + 15);
        Debug.Log("��ȯ ����Ư������ ���� ���� 15�� �������� �ް�, �÷��̾�� 15�� ü���� ȸ���ߴ�");
    }
}