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
            Debug.Log("억압 융합특성으로 인해 상대에게 수갑 30 스택 부여");
            isAssigned = true;
        }
    }
}