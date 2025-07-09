using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/TentacleStrike")]
public class TentacleStrike : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        int stack = (int)(combatManager.enemy.statusEffects["erode_stack"].stack * 0.3f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.statusEffects["mark"].stack += stack;
    }
}