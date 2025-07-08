using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/EvasionChance")]
public class EvasionChance : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.dodgeChance = Mathf.Min(70, combatManager.enemy.stats.dodgeChance + stack);
            Debug.Log($"ȸ�Ƿ� ���� ����� ȸ���� {stack}%p ����");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.stats.dodgeChance = Mathf.Min(70, combatManager.player.stats.dodgeChance + stack);
            Debug.Log($"ȸ�Ƿ� ���� �÷��̾��� ȸ���� {stack}%p ����");
        }
    }
}