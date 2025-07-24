using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Proliferation")]
public class Proliferation : AbilityData
{
    int count = 3;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(count == 0)
        {
            combatManager.enemy.statusEffects["erode_stack"].stack += 12;
            Debug.Log("���� ����Ư������ ���� ��뿡�� ħ�� ���� 12 �ο�");
            count = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}