using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/Act4Shared")]
public class Act4SharedAbility : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 10);
        combatManager.Log("마법소녀의 가호로 적의 체력이 10 회복되었다!");
    }
}