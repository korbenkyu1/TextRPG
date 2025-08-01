using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyHpRecovery")]
public class EnemyHpRecovery : EnemySkillData
{
    [SerializeField]
    public int value;
    public string statusEffectName = "";
    public int stack;
    public bool isTargetingPlayer = false;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.health =
            Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + value);
        if(statusEffectName != "")
        {
            if (isTargetingPlayer)
                combatManager.player.statusEffects[statusEffectName].stack += stack;
            else
                combatManager.enemy.statusEffects[statusEffectName].stack += stack;
        }
    }
}