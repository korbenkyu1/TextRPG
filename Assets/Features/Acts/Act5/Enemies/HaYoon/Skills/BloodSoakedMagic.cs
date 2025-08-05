using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Blood-Soaked Magic")]
public class BloodSoakedMagic: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 1.6f);
        combatManager.player.damages.Add(damage);
        combatManager.enemy.statusEffects["bleed"].stack += 7;
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + 20);
    }
}