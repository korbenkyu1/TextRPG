using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/PureLight")]
public class PureLight : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 0.85f);
        combatManager.player.damages.Add(damage);
        string[] keys = { "paralyze", "poison", "burn", "bleed", "weakness" };
        foreach (string key in keys)
            combatManager.enemy.statusEffects[key].stack = 0;
    }
}