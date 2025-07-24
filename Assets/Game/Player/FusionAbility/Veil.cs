using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Veil")]
public class Veil : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isAssigned)
        {
            combatManager.player.statusEffects["shield"].stack += 30;
            Debug.Log("�帷 ����Ư������ ���� ��ȣ 30 ���� �ο�");
            isAssigned = true;
        }
    }
}