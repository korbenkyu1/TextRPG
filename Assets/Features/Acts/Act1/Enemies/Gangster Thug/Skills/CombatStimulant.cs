using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/CombatStimulant")]
public class CombatStimulant : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health+20);
        combatManager.enemyData.skills[6].weight = 0;
    }
}