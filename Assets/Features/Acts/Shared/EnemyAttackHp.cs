using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyAttackHp")]
public class EnemyAttackHp : EnemySkillData
{
    [SerializeField]
    public int AttackCoefficient;
    public int HpValue;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * AttackCoefficient / 100f);
        combatManager.player.damages.Add(damage);
        combatManager.enemy.stats.health
            = Mathf.Min(combatManager.enemy.stats.maxHealth, combatManager.enemy.stats.health + HpValue);
    }
}