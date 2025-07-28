using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Control")]
public class Control : AbilityData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["corrosion"].stack += 14;
        combatManager.Log("제어로 적은 부식 14 스택을 얻었다!");
    }
}