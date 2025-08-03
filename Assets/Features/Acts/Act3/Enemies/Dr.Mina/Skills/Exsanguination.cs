using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Exsanguination")]
public class Exsanguination : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = combatManager.player.statusEffects["bleed"].stack * 3;
        combatManager.player.damages.Add(damage);
        combatManager.player.statusEffects["bleed"].stack = 0;
    }
}