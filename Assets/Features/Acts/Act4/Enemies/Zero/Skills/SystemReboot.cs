using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/SystemReboot")]
public class SystemReboot : EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int recovery = (int)((combatManager.enemy.stats.maxHealth - combatManager.enemy.stats.health) * 0.2f);
        combatManager.enemy.stats.health += recovery;
    }
}