using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Disable")]
public class Disable : StatusEffectData
{
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            combatManager.player.statusEffects["weekness"].stack += stack;
            combatManager.Log($"����ȭ�� ��ȭ {stack} ������ �����!");
        }
    }
    public override void OnEnemyTurnStart(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            combatManager.enemy.statusEffects["weekness"].stack += stack;
            combatManager.Log($"����ȭ�� ���� ��ȭ {stack} ������ �����!");
        }
    }
}
