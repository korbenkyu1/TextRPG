using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/FinalStruggle")]
public class FinalStruggle: EnemySkillData
{
    public override void OnActivate(CombatManager combatManager)
    {
        string[] keys = { "bleed", "burn", "poison"};
        int damage = (int)(combatManager.enemy.stats.attack * 1.4f);
        combatManager.player.damages.Add(damage);
        foreach(string key in keys)
        {
            combatManager.player.statusEffects[key].stack += 5;
            combatManager.enemy.statusEffects[key].stack += 7;
        }
    }
}