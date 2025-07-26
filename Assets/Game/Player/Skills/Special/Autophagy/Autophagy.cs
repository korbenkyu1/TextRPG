using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerSkill/Autophagy")]
public class Autophagy : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int value = (int)((combatManager.player.stats.maxHealth - 300)*0.2);
        combatManager.player.stats.maxHealth = 300;
        combatManager.player.stats.health = Mathf.Min(combatManager.player.stats.health, 300);
        combatManager.player.statusEffects["bonus_HP"].stack = 0;
        combatManager.player.stats.attack += value;
        combatManager.player.stats.defense += value;
        combatManager.player.statusEffects["eternal_bonus_damage"].stack += value;
        combatManager.player.statusEffects["eternal_bonus_defense"].stack += value;
        combatManager.Log($"공격력이 {value} 증가되었다!");
        combatManager.Log($"방어력이 {value} 증가되었다!");
    }
}