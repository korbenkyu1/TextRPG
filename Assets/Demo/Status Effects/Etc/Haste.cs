using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Haste")]
public class Haste : StatusEffectData
{
    // �ϴ� ���� ����
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {

        }
    }
}