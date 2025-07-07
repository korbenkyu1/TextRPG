using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/FireBreath")]
public class FireBreath : EnemySkillData
{
    public int scalar1;
    public int scalar2;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * scalar1 / 100f + combatManager.player.stats.defense * scalar2 / 100f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.damages.Add(damage);
    }
}
