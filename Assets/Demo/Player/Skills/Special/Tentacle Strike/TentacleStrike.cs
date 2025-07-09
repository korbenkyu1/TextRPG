using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/TentacleStrike")]
public class TentacleStrike : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        if (combatManager.player.stats.critChance >= Random.Range(1, 101))
            damage = (int)(damage * 1.5f);
        int stack = (int)(combatManager.enemy.statusEffects["erode_stack"].stack * 0.3f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.statusEffects["mark"].stack += stack;
    }
}