using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Disable")]
public class Disable : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.statusEffects["weekness"].stack += stack;
            Debug.Log($"무력화로 인해 플레이어에게 약화 {stack}스택 부여");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.statusEffects["weekness"].stack += stack;
            Debug.Log($"무력화로 인해 상대에게 약화 {stack}스택 부여");
        }
    }
}
