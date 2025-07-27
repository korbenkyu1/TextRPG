using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Pierce")]
public class Pierce : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (stack > 0)
        {
            if (!isPlayer)
            {
                combatManager.enemy.stats.health -= stack;
                combatManager.Log($"관통으로 적의 체력이 {stack} 감소되었다!");
                stack = 0;
            }
            else if(isPlayer)
            {
                combatManager.player.stats.health -= stack;
                combatManager.Log($"관통으로 체력이 {stack} 감소되었다!");
                stack = 0;               
            }
        }
    }
}
