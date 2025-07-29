using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/UnstableMutation")]
public class UnstableMutation: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage2 = (int)(combatManager.enemy.stats.health * 0.2f);
        combatManager.player.damages.Add(combatManager.enemy.stats.attack * 2);
        combatManager.player.damages.Add(damage2);
        combatManager.enemy.statusEffects["paralyze"].stack++;
    }
}