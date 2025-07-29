using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/EnemyHpRecovery")]
public class EnemyHpRecovery : EnemySkillData
{
    [SerializeField]
    public int value;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health =
            Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + value);
    }
}