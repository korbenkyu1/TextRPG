using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Reversion")]
public class Reversion : AbilityData
{
    public int count = 3;
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(count == 0)
        {
            int value = combatManager.player.stats.maxHealth;
            value = combatManager.player.stats.maxHealth = Mathf.Max(900, value + 50);
            combatManager.player.stats.health = Mathf.Min(value, combatManager.player.stats.health + 50);
            combatManager.Log("역행으로 현재 체력과 최대 체력이 50 증가되었다!");
            count = 3;
        }
    }
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}