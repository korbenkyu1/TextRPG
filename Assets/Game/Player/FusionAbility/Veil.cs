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
            Debug.Log("장막 융합특성으로 인해 보호 30 스택 부여");
            isAssigned = true;
        }
    }
}