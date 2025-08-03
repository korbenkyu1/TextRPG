using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/BleedingCatalyst")]
public class BleedingCatalyst: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 0.8f);
        combatManager.player.damages.Add(damage);
        combatManager.player.statusEffects["bleed"].stack *= 2;
    }
}