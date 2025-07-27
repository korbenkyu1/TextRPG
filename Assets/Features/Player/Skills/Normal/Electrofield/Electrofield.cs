using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/Electrofield")]
public class Electrofield : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["paralyze"].stack += 2;
    }
}