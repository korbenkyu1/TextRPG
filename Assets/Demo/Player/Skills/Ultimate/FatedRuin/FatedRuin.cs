using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/FatedRuin")]
public class FatedRuin : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["erode_stack"].stack += (int)(combatManager.player.stats.attack * scalar1 / 100f);
    }
}