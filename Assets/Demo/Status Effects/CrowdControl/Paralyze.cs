using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Paralyze")]
public class Paralyze : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.remainingAction = 0;
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"마비로 인해 플레이어 행동 불가\n마비 스택 {stack + 1} >> {stack}");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            combatManager.enemy.remainingAction = 0;
            stack = Mathf.Max(0, stack - 1);
            Debug.Log($"마비로 인해 상대 행동 불가\n마비 스택 {stack + 1} >> {stack}");
        }
    }
}
