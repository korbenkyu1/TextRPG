using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/CarapaceOfTendrils")]
public class CarapaceOfTendrils : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.statusEffects["damage_reduction"].stack +=
            (int)(combatManager.player.stats.defense * scalar1 / 100f);
        combatManager.player.statusEffects["reduction"].stack++;
    }
}