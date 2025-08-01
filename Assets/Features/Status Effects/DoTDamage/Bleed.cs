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
                combatManager.Log($"������ ü���� {stack} ���ҵǾ���!");
            }
            else
            {
                combatManager.enemy.stats.health -= stack;
                combatManager.Log($"������ ���� ü���� {stack} ���ҵǾ���!");
            }
        }
    }
}