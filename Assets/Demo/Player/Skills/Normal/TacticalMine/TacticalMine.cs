using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/TacticalMine")]
public class TacticalMine : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.health * 0.2);
        combatManager.enemy.damages.Add(damage);
    }
}