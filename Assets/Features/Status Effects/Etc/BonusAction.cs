using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusAction")]
public class BonusAction : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.remainingAction += 1;
            stack--;
            combatManager.Log("추가행동으로 추가행동턴이 1 증가되었다!");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            combatManager.enemy.remainingAction += 1;
            stack--;
            combatManager.Log("추가행동으로 적의 추가행동턴이 1 증가되었다!");
        }
    }
}