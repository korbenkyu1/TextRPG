using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/Split")]
public class Split : AbilityData
{
    public int used = 0;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(used != 2)
        {
            if(used == 1 && combatManager.enemy.statusEffects["reincarnation"].stack == 0)
            {
                combatManager.enemy.statusEffects["reincarnation"].stack
                    += (int)(combatManager.enemy.stats.maxHealth / 4);
                used = 2;
            }
            else if(used == 0)
            {
                combatManager.enemy.statusEffects["reincarnation"].stack
                    += (int)(combatManager.enemy.stats.maxHealth / 2);
                used = 1;
            }
        }
    }
}