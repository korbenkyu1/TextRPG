using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Pierce")]
public class Pierce : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            combatManager.player.stats.health -= stack;
            Debug.Log($"�������� ���� �÷��̾�� {stack}�� �������� �Ծ���");
            stack = 0;
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health -= stack;
            Debug.Log($"�������� ���� ���� {stack}�� �������� �Ծ���");
            stack = 0;
        }
    }
}
