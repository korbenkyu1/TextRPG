using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/SuicideBombing")]
public class SuicideBombing : AbilityData
{
    public bool isUsed;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isUsed && combatManager.enemy.stats.health < 20)
        {
            combatManager.player.stats.health -= 20;
            combatManager.enemy.stats.health -= 20;
            combatManager.Log("자폭으로 모두 20의 데미지를 입었다!");
            isUsed = true;
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (!isUsed && combatManager.enemy.stats.health < 20)
        {
            combatManager.player.stats.health -= 20;
            combatManager.enemy.stats.health -= 20;
            combatManager.Log("자폭으로 모두 20의 데미지를 입었다!");
            isUsed = true;
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if (!isUsed && combatManager.enemy.stats.health < 20)
        {
            combatManager.player.stats.health -= 20;
            combatManager.enemy.stats.health -= 20;
            combatManager.Log("자폭으로 모두 20의 데미지를 입었다!");
            isUsed = true;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if (!isUsed && combatManager.enemy.stats.health < 20)
        {
            combatManager.player.stats.health -= 20;
            combatManager.enemy.stats.health -= 20;
            combatManager.Log("자폭으로 모두 20의 데미지를 입었다!");
            isUsed = true;
        }
    }
}