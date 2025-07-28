using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/Stimulant")]
public class Stimulant : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.stats.attack = Mathf.Min(70, combatManager.player.stats.attack + scalar1);
        combatManager.player.remainingAction++;
        combatManager.Log($"공격력이 {scalar1} 증가되었다!");
    }
}