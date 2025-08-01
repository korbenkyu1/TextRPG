using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/IntelligentStrike")]
public class IntelligentStrike: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 0.85f);
        combatManager.enemy.stats.critChance = 25;
        combatManager.player.damages.Add(damage);
    }
}