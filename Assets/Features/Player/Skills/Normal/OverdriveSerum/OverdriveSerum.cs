using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerSkill/OverdriveSerum")]
public class OverdriveSerum : PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.statusEffects["bonus_evasion"].stack += 40;
        combatManager.player.stats.dodgeChance = Mathf.Min(70, combatManager.player.stats.dodgeChance + 40);
        combatManager.player.remainingAction++;
        combatManager.Log("회피율이 40% 증가되었다!");
    }
}