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
            Debug.Log($"플레이어는 {stack}의 독 데미지를 입었다\n독 스택 {stack + 1} >> {stack}");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            stack--;
            Debug.Log($"상대는 {stack}의 독 데미지를 입었다\n독 스택 {stack + 1} >> {stack}");
        }
    }
}
