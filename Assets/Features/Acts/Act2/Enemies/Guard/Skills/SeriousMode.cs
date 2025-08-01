using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/SeriousMode")]
public class SeriousMode: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 1.7f);
        combatManager.enemy.stats.critChance = 100;
        combatManager.player.damages.Add(damage);
        string[] keys = { "bleed", "burn", "poison", "paralyze", "weakness"};
        foreach (string key in keys)
        {
            combatManager.enemy.statusEffects[key].stack = 0;
        }
    }
}