using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/ContinuousStrike")]
public class ContinuousStrike: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * 0.58f);
        int count = Random.Range(2, 7);
        for(int i = 0; i < count; i++)
            combatManager.player.damages.Add(damage);
    }
}