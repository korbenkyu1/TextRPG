using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Control")]
public class Control : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["corrosion"].stack += 14;
        Debug.Log("제어 융합특성으로 인해 상대에게 부식 14 스택 부여");
    }
}