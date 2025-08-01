using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/DesperateStrike")]
public class DesperateStrike: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 1.4f);
        int damage2 = (int)(combatManager.enemy.stats.health * 0.15f);
        combatManager.player.damages.Add(damage);
        combatManager.enemy.stats.health -= damage2;
    }
}