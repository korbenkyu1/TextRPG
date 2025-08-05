using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusAction")]
public class BonusAction : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.remainingAction += 1;
                combatManager.Log("추가행동으로 추가행동턴이 1 증가되었다!");
            }
            else
            {
                combatManager.enemy.remainingAction += 1;
                combatManager.Log("추가행동으로 적의 추가행동턴이 1 증가되었다!");
            }
            stack--;
        }
    }
}