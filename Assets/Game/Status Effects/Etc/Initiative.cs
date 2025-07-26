using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Initiative")]
public class Initiative : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (stack < combatManager.enemy.statusEffects["initiative"].stack)
        {
            combatManager.player.remainingAction = 0;
            combatManager.player.statusEffects["initiative"].stack = 0;
            combatManager.enemy.statusEffects["initiative"].stack = 0;
            combatManager.Log("���������� ���� ���� �ൿ�Ѵ�!");
        }
    }
}