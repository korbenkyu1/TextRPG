using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Disable")]
public class Disable : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.statusEffects["weekness"].stack += stack;
            Debug.Log($"����ȭ�� ���� �÷��̾�� ��ȭ {stack}���� �ο�");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.statusEffects["weekness"].stack += stack;
            Debug.Log($"����ȭ�� ���� ��뿡�� ��ȭ {stack}���� �ο�");
        }
    }
}
