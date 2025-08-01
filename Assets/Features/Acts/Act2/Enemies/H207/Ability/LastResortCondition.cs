using UnityEngine;

[CreateAssetMenu(menuName = "Data/Ability/LastResort")]
public class LastResort : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (combatManager.enemy.stats.health <= (int)combatManager.enemy.stats.maxHealth * 0.3f)
            combatManager.enemyData.skills[3].weight = 1;
    }
}