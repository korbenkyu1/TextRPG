using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/TempAttack")]
public class TempAttack : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.damages.Add(1);
    }
}
