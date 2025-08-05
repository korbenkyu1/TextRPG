using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyAttackCrit")]
public class EnemyAttackCrit : EnemySkillData
{
    [SerializeField]
    public int AttackCoefficient;
    public int critical;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.enemy.stats.critChance = critical;
        int damage = (int)(combatManager.enemy.stats.attack * AttackCoefficient / 100f);
        combatManager.player.damages.Add(damage);
    }
}