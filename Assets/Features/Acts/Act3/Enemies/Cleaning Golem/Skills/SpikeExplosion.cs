using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/SpikeExplosion")]
public class SpikeExplosion: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.statusEffects["reflect"].stack * 0.5f);
        combatManager.player.damages.Add(damage);
    }
}