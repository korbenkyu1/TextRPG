using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Cycle")]
public class Cycle : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 15;
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health + 15);
        combatManager.Log("��ȯ���� ���� ü���� 15 ���ҵǾ���, �÷��̾��� ü���� 15 ȸ���Ǿ���!");
    }
}