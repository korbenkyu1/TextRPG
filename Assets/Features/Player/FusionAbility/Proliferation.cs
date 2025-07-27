using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Proliferation")]
public class Proliferation : AbilityData
{
    public int count = 3;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(count == 0)
        {
            combatManager.enemy.statusEffects["erode_stack"].stack += 12;
            combatManager.Log("���� �������� ħ�� 12 ������ �����!");
            count = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}