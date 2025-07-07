using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/DoTDamage/Burn")]
public class Burn : StatusEffectData
{
    public override void OnPlayerTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.player.stats.health -= stack;
            Debug.Log($"플레이어는 {stack}의 화상 데미지를 입었다");
        }
    }
    public override void OnEnemyTurnEnd(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            Debug.Log($"상대는 {stack}의 화상 데미지를 입었다");
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"플레이어의 화상 스택 {stack + 1} >> {stack}");
        }
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"상대의 화상 스택 {stack + 1} >> {stack}");
        }
    }
}
