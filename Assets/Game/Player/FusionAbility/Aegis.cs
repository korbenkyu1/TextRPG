using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Aegis")]
public class Aegis : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (!isAssigned)
        {
            combatManager.player.statusEffects["reduction"].stack += 45;
            Debug.Log("ö�� ����Ư������ ���� �÷��̾�� �氨 45 ���� �ο�");
            isAssigned = true;
        }
    }
}