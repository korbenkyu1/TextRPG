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
            combatManager.Log("���� ������� ���� ���� 30 ������ �����!");
            isAssigned = true;
        }
    }
}