using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/DeepInfiltration")]
public class DeepInfiltration: PlayerSkillData
{
    [SerializeField]
    int scalar1, scalar2;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        int stack = (int)(combatManager.enemy.statusEffects["erode_stack"].stack * scalar2 / 100f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.statusEffects["corrosion"].stack += stack;
    }
}