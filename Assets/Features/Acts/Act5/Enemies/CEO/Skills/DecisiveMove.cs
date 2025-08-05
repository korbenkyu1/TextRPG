using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/DecisiveMove")]
public class DecisiveMove : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.critChance = 90;
        combatManager.player.damages.Add(combatManager.enemy.stats.attack * 2);
        combatManager.enemy.stats.health -= (int)(combatManager.enemy.stats.maxHealth * 0.4f);
    }
}