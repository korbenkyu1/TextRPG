using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/DrugAddiction")]
public class DrugAddiction: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health 
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 80);
        combatManager.enemy.statusEffects["critical_chance"].stack += 20;
        combatManager.enemy.statusEffects["poison"].stack += 30;
    }
}