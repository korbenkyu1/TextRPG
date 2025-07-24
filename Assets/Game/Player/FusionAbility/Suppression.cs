using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Suppression")]
public class Suppression : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isAssigned)
        {
            combatManager.enemy.statusEffects["restrain"].stack += 30;
            Debug.Log("��� ����Ư������ ���� ��뿡�� ���� 30 ���� �ο�");
            isAssigned = true;
        }
    }
}