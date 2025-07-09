using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/RitualSeverance")]
public class RitualSeverance : PlayerSkillData
{
    [SerializeField]
    int scalar1, scalar2;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        if (combatManager.player.stats.critChance >= Random.Range(1, 101))
            damage = (int)(damage * 1.5);
        int specialDamage = (int)(combatManager.player.stats.attack * scalar2 / 100f);
        
        combatManager.enemy.damages.Add(damage);
        combatManager.player.damages.Add(specialDamage);
        if (--combatManager.enemy.statusEffects["erode_stack"].stack < 0)
            combatManager.enemy.statusEffects["erode_stack"].stack = 0;
    }
}
