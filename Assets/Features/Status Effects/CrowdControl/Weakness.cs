using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Weakness")]
public class Weakness : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.attack = Mathf.Max(0, combatManager.player.stats.attack - stack);
                combatManager.Log($"약화로 공격력이 {stack} 감소되었다!");
            }
            else
            {
                combatManager.enemy.stats.attack = Mathf.Max(0, combatManager.enemy.stats.attack - stack);
                combatManager.Log($"약화로 적의 공격력이 {stack} 감소되었다!");
            }
        }
    }
}
