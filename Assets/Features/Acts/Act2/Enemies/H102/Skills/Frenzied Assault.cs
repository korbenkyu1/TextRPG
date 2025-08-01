using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/FrenziedAssault")]
public class FrenziedAssault : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 1.5f);
        int damage2 = (int)(combatManager.enemy.stats.maxHealth * 0.1f);
        combatManager.player.damages.Add(damage);
        combatManager.enemy.stats.health -= damage2;
    }
}