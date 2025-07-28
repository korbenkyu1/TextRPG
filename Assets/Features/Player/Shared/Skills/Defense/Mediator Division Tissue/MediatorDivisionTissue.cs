using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/MediatorDivisionTissue")]
public class MediatorDivisionTissue : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int stack = (int)(combatManager.player.stats.defense * 0.3f);
        int heal = (int)(combatManager.player.stats.defense * scalar1 / 100f);

        combatManager.player.statusEffects["shield"].stack += stack;
        combatManager.player.statusEffects["erode_stack"].stack
            = Mathf.Max(0, combatManager.player.statusEffects["erode_stack"].stack - 1);
        combatManager.player.stats.health += heal;
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health);
    }
}