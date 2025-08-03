using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/HaYoonAbility")]
public class HaYoonAbility : AbilityData
{
    int count = 0;
    public override void OnTurnStart(CombatManager combatmanager)
    {
        count++;
        if (count == 2)
        {
            combatmanager.enemy.stats.maxHealth += 30;
            combatmanager.enemy.stats.health += 30;
            combatmanager.Log("마법소녀 하윤의 특성으로 적의 최대체력이 30 증가되었다!");
            count = 0;
        }
    }
}