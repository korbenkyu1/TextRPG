using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/TactileOverrun")]
public class TactileOverrun: PlayerSkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.stats.critChance = Mathf.Min(99, combatManager.player.stats.critChance + 25);
        combatManager.player.remainingAction += 2;
    }
}