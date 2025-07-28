using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Control")]
public class Control : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["corrosion"].stack += 14;
        combatManager.Log("����� ���� �ν� 14 ������ �����!");
    }
}