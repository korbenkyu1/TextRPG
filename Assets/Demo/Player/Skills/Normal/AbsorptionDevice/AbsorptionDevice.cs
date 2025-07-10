using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/AbsorptionDevice")]
public class AbsorptionDevice : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int stack = (int)(combatManager.player.stats.defense * scalar1 / 100f);
        combatManager.player.statusEffects["damage_reduction"].stack += stack;
        combatManager.player.remainingAction++;
    }
}