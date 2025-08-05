using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/SystemOverload")]
public class SystemOverload: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.damages.Add(combatManager.enemy.stats.attack * 3);
        combatManager.enemy.stats.maxHealth = (int)(combatManager.enemy.stats.maxHealth / 2);
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health);
    }
}