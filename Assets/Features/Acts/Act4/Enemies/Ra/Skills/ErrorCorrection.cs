using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/ErrorCorrection")]
public class ErrorCorrection: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 80);
        string[] keys = { "poison", "burn", "weakness", "bleed" };
        foreach (string key in keys)
            combatManager.enemy.statusEffects[key].stack = 0;
    }
}