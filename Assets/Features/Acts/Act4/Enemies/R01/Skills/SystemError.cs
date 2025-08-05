using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/SystemError")]
public class SystemError: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["paralyze"].stack++;
        combatManager.enemy.statusEffects["burn"].stack += 30;
        combatManager.player.statusEffects["burn"].stack += 30;
    }
}