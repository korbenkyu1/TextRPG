using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/MentalDisorder")]
public class MentalDisorder : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["paralyze"].stack++;
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 35);
    }
}