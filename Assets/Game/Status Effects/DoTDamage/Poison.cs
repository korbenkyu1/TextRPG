using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Poison")]
public class Poison : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer) 
        {
            combatManager.player.stats.health -= stack;
            stack--;
            combatManager.Log($"������ ü���� {stack} ���ҵǾ���!");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            stack--;
            combatManager.Log($"������ ���� ü���� {stack} ���ҵǾ���!");
        }
    }
}
