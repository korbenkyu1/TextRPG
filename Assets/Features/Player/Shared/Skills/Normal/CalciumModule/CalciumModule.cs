using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerSkill/CalciumModule")]
public class CalciumModule : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.stats.defense = Mathf.Min(70, combatManager.player.stats.defense + scalar1);
        combatManager.player.remainingAction++;
        combatManager.Log($"방어력이 {scalar1} 증가되었다!");
    }
}