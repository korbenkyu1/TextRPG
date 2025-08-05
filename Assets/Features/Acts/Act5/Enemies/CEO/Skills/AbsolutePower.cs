using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/AbsolutePower")]
public class AbsolutePower: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int value = (int)(combatManager.enemy.stats.attack * 0.3f);
        combatManager.player.damages.Add(combatManager.enemy.stats.attack);
        combatManager.enemy.statusEffects["eternal_bonus_damage"].stack += value;
    }
}