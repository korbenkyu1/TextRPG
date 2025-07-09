using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Data/PlayerSkill/DeepInfiltration")]
public class DeepInfiltration: PlayerSkillData
{
    [SerializeField]
    int scalar1, scalar2;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        if (combatManager.player.stats.critChance >= Random.Range(1, 101))
            damage = (int)(damage * 1.5);
        int stack = (int)(combatManager.enemy.statusEffects["erode_stack"].stack * scalar2 / 100f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.statusEffects["corrosion"].stack += stack;
    }
}