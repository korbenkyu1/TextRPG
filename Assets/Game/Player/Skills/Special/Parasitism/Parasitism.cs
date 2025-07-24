using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/Parasitism")]
public class Parasitism : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["erode_stack"].stack += 2;
        combatManager.enemy.statusEffects["poison"].stack += combatManager.enemy.statusEffects["erode_stack"].stack;
    }
}