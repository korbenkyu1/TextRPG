using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/EquivalentExchange")]
public class EquivalentExchange : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int stack = combatManager.enemy.statusEffects["erode_stack"].stack*50;
        combatManager.enemy.statusEffects["erode_stack"].stack = 0;
        combatManager.player.stats.health += stack;
        combatManager.player.stats.health = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health);
        combatManager.Log($"체력이 {stack} 증가되었다!");
    }
}