using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/RegenerativeInstinct")]
public class RegenerativeInstinct : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        string[] keys = { "burn", "poison", "bleed" };
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 40);
        foreach (string key in keys)
        {
            combatManager.enemy.statusEffects[key].stack
                = Mathf.Max(0, combatManager.enemy.statusEffects[key].stack - 5);
        }
    }
}