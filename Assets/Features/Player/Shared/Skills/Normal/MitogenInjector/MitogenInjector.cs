using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/MitogenInjector")]
public class MitogenInjector : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int heal = (int)((combatManager.player.stats.maxHealth - combatManager.player.stats.health) * scalar1 / 100f);
        combatManager.player.stats.health += heal;
    }
}