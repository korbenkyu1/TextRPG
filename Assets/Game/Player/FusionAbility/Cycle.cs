using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Cycle")]
public class Cycle : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 15;
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health + 15);
        combatManager.Log("순환으로 적의 체력이 15 감소되었고, 플레이어의 체력이 15 회복되었다!");
    }
}