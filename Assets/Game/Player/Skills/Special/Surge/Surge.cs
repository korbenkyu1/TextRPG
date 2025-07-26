using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerSkill/Surge")]
public class Surge : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.stats.attack = Mathf.Max(70, combatManager.player.stats.attack + scalar1);
        combatManager.player.statusEffects["bonus_damage"].stack += scalar1;
        combatManager.Log($"공격력이 {scalar1} 증가되었다!");
    }
}