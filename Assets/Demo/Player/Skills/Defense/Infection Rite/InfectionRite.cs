using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/InfectionRite")]
public class InfectionRite: PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.statusEffects["evasion_chance"].stack++;
        combatManager.enemy.statusEffects["erode_stack"].stack += 2;
        combatManager.enemy.statusEffects["poison"].stack += (int)(combatManager.player.stats.defense * 0.3);
    }
}