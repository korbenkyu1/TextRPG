using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/BackupSystem")]
public class BackupSystem : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 40);
        combatManager.enemy.statusEffects["poison"].stack = 0;
    }
}