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
        combatManager.player.statusEffects["erode_stack"].stack--;
        combatManager.player.stats.health += heal;
        if(combatManager.player.stats.health > combatManager.player.stats.maxHealth)
            combatManager.player.stats.health = combatManager.player.stats.maxHealth;
    }
}