using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/NullGrid")]
public class NullGrid: PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.attack * scalar1 / 100f);
        int stack = (int)(combatManager.enemy.statusEffects["erode_stack"].stack * 0.3);

        for(int i = 0; i < 2; i++)
        {
            if (combatManager.player.stats.critChance >= Random.Range(1, 101))
                combatManager.enemy.damages.Add((int)(damage * 1.5));
            else
                combatManager.enemy.damages.Add(damage);
        }
        combatManager.enemy.statusEffects["unevadible"].stack += stack;
    }
}