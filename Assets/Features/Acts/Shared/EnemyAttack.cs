using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyAttack")]
public class EnemyAttack : EnemySkillData
{
    [SerializeField]
    public int attackCoefficient;
    public int attackCount;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack*(attackCoefficient/100f));
        for(int i = 0; i < attackCount; i++)
            combatManager.player.damages.Add(damage);
    }
}