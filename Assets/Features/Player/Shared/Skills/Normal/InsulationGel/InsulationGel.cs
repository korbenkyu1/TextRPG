using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/InsulationGel")]
public class InsulationGel : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.statusEffects["unstoppable"].stack += 2;
        combatManager.player.remainingAction++;
    }
}