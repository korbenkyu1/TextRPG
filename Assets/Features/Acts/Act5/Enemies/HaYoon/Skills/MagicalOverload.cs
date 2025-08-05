using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/MagicalOverload")]
public class MagicalOverload : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 2.5f);
        combatManager.player.damages.Add(damage);
        int value = (int)(combatManager.enemy.stats.maxHealth * 0.4f);
        combatManager.enemy.stats.health -= value;
    }
}