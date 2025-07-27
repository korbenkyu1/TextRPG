using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Disable")]
public class Disable : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.statusEffects["weekness"].stack += stack;
            combatManager.Log($"무력화로 약화 {stack} 스택을 얻었다!");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.statusEffects["weekness"].stack += stack;
            combatManager.Log($"무력화로 적이 약화 {stack} 스택을 얻었다!");
        }
    }
}
