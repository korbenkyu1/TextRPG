using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/RitualSeverance")]
public class RitualSeverance : PlayerSkillData
{
    [SerializeField]
    int scalar1, scalar2;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        int specialDamage = (int)(combatManager.player.stats.attack * scalar2 / 100f);
        
        combatManager.enemy.damages.Add(damage);
        combatManager.player.stats.health -= specialDamage;
        if (--combatManager.enemy.statusEffects["erode_stack"].stack < 0)
            combatManager.enemy.statusEffects["erode_stack"].stack = 0;
    }
}
