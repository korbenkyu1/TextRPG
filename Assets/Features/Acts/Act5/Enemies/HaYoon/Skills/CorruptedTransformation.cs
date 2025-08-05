using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/CorruptedTransformation")]
public class CorruptedTransformation : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["eternal_bonus_damage"].stack += 30;
        string[] keys = { "poison", "burn", "bleed", "weakness" };
        foreach (string key in keys)
            combatManager.enemy.statusEffects[key].stack = 0;
    }
}