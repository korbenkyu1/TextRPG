using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Critical/CriticalChance")]
public class CriticalChance : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.stats.critChance += stack;
            Debug.Log($"ġ��Ÿ Ȯ�� ������ ���� �÷��̾��� ġ��Ÿ Ȯ�� {stack}%p ���");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.player.stats.critChance += stack;
            Debug.Log($"ġ��Ÿ Ȯ�� ������ ���� ����� ġ��Ÿ Ȯ�� {stack}%p ���");
        }
    }
}
