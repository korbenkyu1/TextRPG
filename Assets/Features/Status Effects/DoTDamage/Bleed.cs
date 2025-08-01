using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Bleed")]
public class Bleed : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.health -= stack;
                combatManager.Log($"출혈로 체력이 {stack} 감소되었다!");
            }
            else
            {
                combatManager.enemy.stats.health -= stack;
                combatManager.Log($"출혈로 적의 체력이 {stack} 감소되었다!");
            }
        }
    }
}