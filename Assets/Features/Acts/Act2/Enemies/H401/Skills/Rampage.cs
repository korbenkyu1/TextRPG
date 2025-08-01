using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Rampage")]
public class Rampage : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 1.5f);
        foreach (string key in combatManager.enemy.statusEffects.Keys)
            combatManager.enemy.statusEffects[key].stack = 0;
        combatManager.player.damages.Add(damage);
    }
}