using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/UnstableStrike")]
public class UnstableStrike: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * Random.Range(30, 201) / 100f);
        combatManager.player.damages.Add(damage);
    }
}