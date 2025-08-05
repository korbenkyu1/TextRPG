using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/PerfectSmile")]
public class PerfectSmile : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.damages.Add(combatManager.enemy.stats.attack);
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 30);
    }
}