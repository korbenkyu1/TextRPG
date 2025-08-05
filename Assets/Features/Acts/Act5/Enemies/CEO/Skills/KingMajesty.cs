using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/KingMajesty")]
public class KingMajesty : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.critChance = 100;
        combatManager.player.damages.Add((int)(combatManager.enemy.stats.attack * 2.5f));
        combatManager.enemy.stats.attack -= 30;
        combatManager.enemy.stats.defense -= 30;
        combatManager.enemy.stats.maxHealth -= 100;
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health);
    }
}